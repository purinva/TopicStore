namespace Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiServices(
            this IServiceCollection services, 
            IConfiguration configuration)
        {
            services.AddOpenApi();

            return services;
        }

        public static WebApplication UseApiServices(
            this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            return app;
        }
    }
}
