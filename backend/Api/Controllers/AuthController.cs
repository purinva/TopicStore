using Application.Dtos.Users;
using Application.Security;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Data.DataDbContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Exceptions;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(
        ApplicationDbContext dbContext,
        IJwtProvider jwtProvider,
        IPasswordService passwordService,
        IMapper mapper)
        : ControllerBase
    {
        [HttpPost("login")]
        public async Task<IResult> Login(
            [FromBody] LoginUserDto loginUserDto,
            CancellationToken cancellationToken)
        {
            var user = await dbContext.Users
                .FirstOrDefaultAsync(u => u.Email == loginUserDto.Email, 
                    cancellationToken);

            if (user == null || passwordService.VerifyPassword(
                loginUserDto.Password!, user.PasswordHash!))
            {
                throw new UnauthorizedException("Такой пользователь не зарегистрирован");
            }

            var token = jwtProvider
                .GenerateToken(user.Id, loginUserDto.Email!);

            return Results.Ok(new { Token = token });
        }

        [HttpPost("register")]
        public async Task<IResult> Register(
            [FromBody] RegisterUserDto registerUserDto,
            CancellationToken cancellationToken)
        {
            var user = await dbContext.Users
                .FirstOrDefaultAsync(u => u.Email == registerUserDto.Email,
                    cancellationToken);

            if (user != null)
            {
                throw new ConflictException("Такой пользователь уже существует");
            }

            var newUser = mapper.Map<User>(registerUserDto);

            newUser.PasswordHash = passwordService
                .HashPassword(registerUserDto.Password!);

            await dbContext.Users.AddAsync(newUser);

            var token = jwtProvider
                .GenerateToken(newUser.Id, newUser.Email!);

            return Results.Ok(new { Token = token });
        }
    }
}