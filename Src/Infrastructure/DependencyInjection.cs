using Microsoft.Extensions.DependencyInjection;
using SimpleCalculatorCsharp.Src.Infrastructure.Calculators;
using SimpleCalculatorCsharp.Src.Infrastructure.Parsers;
using SimpleCalculatorCsharp.Src.Infrastructure.Factories;
using SimpleCalculatorCsharp.Src.Infrastructure.OperationStrategies;
using SimpleCalculatorCsharp.Src.Infrastructure.Repositories;

namespace SimpleCalculatorCsharp.Src.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IExpressionParser, ShuntingYardParser>();
            services.AddScoped<ICalculator, RPNCalculator>();
            
            services.AddScoped<AddOperationStrategy>();
            services.AddScoped<SubtractOperationStrategy>();
            services.AddScoped<MultiplyOperationStrategy>();
            services.AddScoped<DivideOperationStrategy>();
            services.AddScoped<IOperationStrategyFactory, OperationStrategyFactory>();
            
            services.AddSingleton<ICalculationHistoryRepository, InMemoryHistoryRepository>();
            
            return services;
        }
    }
}