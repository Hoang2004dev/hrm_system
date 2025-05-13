using HRM.Application.Interfaces.Services;
using HRM.Infrastructure.Auth;
using HRM.Infrastructure.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HRM.Infrastructure.DependencyInjection
{
    public static class InfrastructureDI
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IHashingService, HashingService>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<IJwtService, JwtService>();
            // Đăng ký các repository khác...

            // Cấu hình JWT Authentication
            services.AddJwtAuthentication(config);

            return services;
        }
    }

}
