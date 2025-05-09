using FluentValidation;
using HRM.Application.Behaviors;
using HRM.Application.Interfaces.Repositories;
using HRM.Application.Specifications.Base;
using HRM.Application.Specifications.Projection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

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

            services.AddScoped(typeof(ISpecificationEvaluator<>), typeof(DefaultSpecificationEvaluator<>));

            return services;
        }
    }
}
