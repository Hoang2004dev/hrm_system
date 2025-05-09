using HRM.Application.Interfaces.Repositories;
using HRM.Persistence.Contexts;
using HRM.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HRM.Persistence.DependencyInjection
{
    public static class PersistenceDI
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<HRMDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserProjectRoleRepository, UserProjectRoleRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            // Đăng ký các repository khác...

            return services;
        }
    }
}
