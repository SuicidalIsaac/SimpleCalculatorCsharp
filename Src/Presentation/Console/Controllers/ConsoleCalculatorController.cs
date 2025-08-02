using SimpleCalculatorCsharp.Src.Application.Commands;
using MediatR;
using SimpleCalculatorCsharp.Src.Presentation.Console.InputHandlers;
using SimpleCalculatorCsharp.Src.Presentation.Console.Presenters;
using SimpleCalculatorCsharp.Src.Presentation.Console.Views;

namespace SimpleCalculatorCsharp.Src.Presentation.Console.Controllers
{
    public class ConsoleCalculatorController
    {
        private readonly IMediator _mediator;
        private readonly IConsoleView _view;
        private readonly IInputHandler _inputHandler;
        private readonly CalculationResultPresenter _presenter;
        private readonly IHistoryPrinter _historyPrinter;

        public ConsoleCalculatorController(
            IMediator mediator,
            IConsoleView view,
            IInputHandler inputHandler,
            CalculationResultPresenter presenter,
            IHistoryPrinter historyPrinter)
        {
            _mediator = mediator;
            _view = view;
            _inputHandler = inputHandler;
            _presenter = presenter;
            _historyPrinter = historyPrinter;
        }

        public void Run()
        {
            _view.PrintLine("Type 'exit' to quit, 'history' to show last calculations");
            
            while (true)
            {
                try
                {
                    string input = _inputHandler.GetInput();
                    
                    if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                        break;
                    
                    if (input.Equals("history", StringComparison.OrdinalIgnoreCase))
                    {
                        _historyPrinter.PrintHistory();
                        continue;
                    }

                    ProcessExpression(input);
                }
                catch (Exception ex)
                {
                    _view.PrintLine($"Error: {ex.Message}");
                }
            }
        }

        private void ProcessExpression(string expression)
        {
            var command = new CalculateExpressionCommand(expression);
            var result = _mediator.Send(command).Result;
            _presenter.Present(result);
        }
    }
}