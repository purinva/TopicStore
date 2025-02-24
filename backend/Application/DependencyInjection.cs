using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Application.Mapping;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(MappingProfile).Assembly);

            return services;
        }
    }
}