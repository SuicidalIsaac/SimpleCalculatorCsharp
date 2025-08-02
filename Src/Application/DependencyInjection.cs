using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;
using SimpleCalculatorCsharp.Src.Application.Pipelines;
using SimpleCalculatorCsharp.Src.Application.Interfaces;
using SimpleCalculatorCsharp.Src.Application.Services;

namespace SimpleCalculatorCsharp.Src.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingPipelineBehavior<,>));
            
            services.AddScoped<ICalculationService, CalculationService>();
            services.AddScoped<IHistoryService, HistoryService>();
            
            return services;
        }
    }
}