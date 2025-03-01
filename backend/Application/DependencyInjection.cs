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