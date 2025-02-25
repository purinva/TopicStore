using Application.Security;
using Infrastructure.Data.DataDbContext;
using Infrastructure.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => 
            options.UseSqlServer(configuration
                .GetConnectionString("DefaultConnection")));

            services.AddScoped<IPasswordService, PasswordService>();
            services.AddScoped<IJwtProvider, JwtProvider>();

            return services;
        }
    }
}