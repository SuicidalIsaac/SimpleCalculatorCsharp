using Microsoft.Extensions.DependencyInjection;
using SimpleCalculatorCsharp.Src.Application;
using SimpleCalculatorCsharp.Src.Domain;
using SimpleCalculatorCsharp.Src.Infrastructure;
using SimpleCalculatorCsharp.Src.Presentation.Console.Views;
using SimpleCalculatorCsharp.Src.Presentation.Console.Presenters;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace SimpleCalculatorCsharp.Src.CompositionRoot
{
    public static class ServiceProviderFactory
    {
        public static ServiceProvider Create(bool withLogger)
        {
            var services = new ServiceCollection();
            
            if (withLogger)
            {
                services.AddLogging(logging => 
                {
                    logging.AddConsole();
                    logging.SetMinimumLevel(LogLevel.Information);
                });
            }
            else
            {
                services.AddSingleton<ILoggerFactory, NullLoggerFactory>();
                services.AddSingleton(typeof(ILogger<>), typeof(NullLogger<>));
            }
            
            services.AddDomain();
            services.AddApplication();
            services.AddInfrastructure();
            
            services.AddMediatR(cfg => 
                cfg.RegisterServicesFromAssemblies(
                    typeof(Application.DependencyInjection).Assembly,
                    typeof(Infrastructure.DependencyInjection).Assembly));
            
            services.AddSingleton<IConsoleView, ConsoleView>();
            services.AddScoped<CalculationResultPresenter>();
            services.AddScoped<IHistoryPrinter, ConsoleHistoryPrinter>();
            
            return services.BuildServiceProvider();
        }
    }
}