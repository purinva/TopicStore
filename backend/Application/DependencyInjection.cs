﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Application.Mapping;
using Application.Validators;
using FluentValidation;
using Application.Dtos.Topics;
using Application.Dtos.Users;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(MappingProfile).Assembly);
            services.AddScoped<IValidator<CreateTopicDto>, CreateTopicDtoValidator>();
            services.AddScoped<IValidator<UpdateTopicDto>, UpdateTopicDtoValidator>();
            services.AddScoped<IValidator<LoginUserDto>, LoginUserDtoValidator>();
            services.AddScoped<IValidator<RegisterUserDto>, RegisterUserDtoValidator>();

            return services;
        }
    }
}