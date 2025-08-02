using SimpleCalculatorCsharp.Src.Application.Queries;
using MediatR;
using SimpleCalculatorCsharp.Src.Presentation.Console.Views;
using FluentValidation;

namespace SimpleCalculatorCsharp.Src.Presentation.Console.Presenters
{
    public class ConsoleHistoryPrinter : IHistoryPrinter
    {
        private readonly IMediator _mediator;
        private readonly IConsoleView _view;

        public ConsoleHistoryPrinter(IMediator mediator, IConsoleView view)
        {
            _mediator = mediator;
            _view = view;
        }

        public void PrintHistory()
        {
            try
            {
                var query = new GetCalculationHistoryQuery(10);
                var history = _mediator.Send(query).Result;
                
                _view.PrintLine("Calculation History:");
                foreach (var entry in history.Entries)
                {
                    _view.PrintLine($"[{entry.Timestamp:HH:mm:ss}] {entry.Expression} = {entry.Result}");
                }
                _view.PrintLine("");
            }
            catch (ValidationException ex)
            {
                _view.PrintLine("Validation error:");
                foreach (var error in ex.Errors)
                {
                    _view.PrintLine($"- {error.ErrorMessage}");
                }
            }
            catch (Exception ex)
            {
                _view.PrintLine($"Error retrieving history: {ex.Message}");
            }
        }
    }
}