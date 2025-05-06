using FluentValidation;
using HRM.Application.Behaviors;
using HRM.Application.UseCases.Department.Commands;
using HRM.Application.UseCases.Department.Validators;
using HRM.Domain.Interfaces;
using MediatR;
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

            // Register pipeline behaviors
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            // Register other behaviors if needed
            // services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            // services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehavior<,>));

            return services;
        }
    }
}
