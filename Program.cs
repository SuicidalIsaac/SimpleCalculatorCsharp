using SimpleCalculatorCsharp.Src.Presentation.Console.Controllers;
using SimpleCalculatorCsharp.Src.Presentation.Console.InputHandlers;
using SimpleCalculatorCsharp.Src.Presentation.Console.Presenters;
using SimpleCalculatorCsharp.Src.Presentation.Console.Views;
using SimpleCalculatorCsharp.Src.CompositionRoot;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace SimpleCalculatorCsharp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool withLogger = args.Contains("withLogger");
            var cleanArgs = args.Where(a => a != "withLogger").ToArray();
            
            var provider = ServiceProviderFactory.Create(withLogger);
            
            var view = provider.GetRequiredService<IConsoleView>();
            var inputHandler = InputHandlerFactory.Create(cleanArgs, view);
            
            var controller = new ConsoleCalculatorController(
                provider.GetRequiredService<IMediator>(),
                view,
                inputHandler,
                provider.GetRequiredService<CalculationResultPresenter>(),
                provider.GetRequiredService<IHistoryPrinter>());
            
            controller.Run();
        }
    }

    public static class InputHandlerFactory
    {
        public static IInputHandler Create(string[] args, IConsoleView view)
        {
            if (args.Length > 0)
            {
                return new CommandLineInputHandler(args);
            }
            return new InteractiveInputHandler(view);
        }
    }
}