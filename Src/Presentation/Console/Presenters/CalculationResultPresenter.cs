using SimpleCalculatorCsharp.Src.Application.DTOs;
using SimpleCalculatorCsharp.Src.Presentation.Console.Views;

namespace SimpleCalculatorCsharp.Src.Presentation.Console.Presenters
{
    public class CalculationResultPresenter
    {
        private readonly IConsoleView _view;

        public CalculationResultPresenter(IConsoleView view)
        {
            _view = view;
        }

        public void Present(CalculationResultDto result)
        {
            _view.PrintLine($">>> {result.Result}");
            _view.PrintLine("───────");
        }
    }
}