using FluentValidation;
using HRM.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Application.DependencyInjection
{
    public static class ApplicationDI
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApplicationDI).Assembly));
            services.AddValidatorsFromAssembly(typeof(ApplicationDI).Assembly);
            services.AddAutoMapper(typeof(ApplicationDI).Assembly);

            return services;
        }
    }

}
