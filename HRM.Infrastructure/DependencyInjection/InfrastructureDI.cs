using HRM.Application.Interfaces;
using HRM.Domain.Interfaces;
using HRM.Infrastructure.Auth;
using HRM.Infrastructure.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Infrastructure.DependencyInjection
{
    public static class InfrastructureDI
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IHashingService, HashingService>();
            // Đăng ký các repository khác...

            // Cấu hình JWT Authentication
            services.AddJwtAuthentication(config);

            return services;
        }
    }

}
