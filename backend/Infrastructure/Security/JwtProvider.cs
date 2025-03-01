namespace Infrastructure.Security
{
    public class JwtProvider(IConfiguration configuration) : IJwtProvider
    {
        public string GenerateToken(Guid id, string username)
        {
            var key = Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!);

            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, id.ToString()),
                new(ClaimTypes.Name, username)
            };

            var credentials = new SigningCredentials(
                new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}