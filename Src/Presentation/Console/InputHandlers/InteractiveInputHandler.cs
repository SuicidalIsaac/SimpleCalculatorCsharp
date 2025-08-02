using SimpleCalculatorCsharp.Src.Presentation.Console.Views;

namespace SimpleCalculatorCsharp.Src.Presentation.Console.InputHandlers
{
    public class InteractiveInputHandler : IInputHandler
    {
        private readonly IConsoleView _view;

        public InteractiveInputHandler(IConsoleView view)
        {
            _view = view;
        }

        public string GetInput()
        {
            _view.Print(">>> ");
            return _view.Input();
        }
    }
}