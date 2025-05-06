using HRM.Application.Interfaces;
using HRM.Domain.Interfaces;
using HRM.Persistence.Contexts;
using HRM.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Persistence.DependencyInjection
{
    public static class PersistenceDI
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<HRMDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserProjectRoleRepository, UserProjectRoleRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();

            // Đăng ký các repository khác...

            return services;
        }
    }
}
