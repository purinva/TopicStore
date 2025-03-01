namespace Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiServices(
            this IServiceCollection services, 
            IConfiguration configuration)
        {
            services.AddSwaggerGen();
            services.AddOpenApi();

            var jwtKey = Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!);

            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(jwtKey)
                    };
                });

            services.AddCors(options =>
            {
                options.AddPolicy("react-policy", policy =>
                {
                    policy.AllowAnyHeader()
                        .AllowAnyMethod()
                        .WithOrigins("http://localhost:3000");
                });
            });

            services.AddMediatR(config => config
            .RegisterServicesFromAssembly(typeof(CreateTopicCommandHandler).Assembly)
            .RegisterServicesFromAssembly(typeof(DeleteTopicCommandHandler).Assembly)
            .RegisterServicesFromAssembly(typeof(UpdateTopicCommandHandler).Assembly)
            .RegisterServicesFromAssembly(typeof(GetAllTopicsQueryHandler).Assembly)
            .RegisterServicesFromAssembly(typeof(GetTopicByIdQueryHandler).Assembly));

            services.AddAuthorization();
            services.AddControllers();

            return services;
        }

        public static WebApplication UseApiServices(
            this WebApplication app)
        {
            app.UseCors("react-policy");

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();

            return app;
        }
    }
}