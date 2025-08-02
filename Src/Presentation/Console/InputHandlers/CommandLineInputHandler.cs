namespace SimpleCalculatorCsharp.Src.Presentation.Console.InputHandlers
{
    public class CommandLineInputHandler : IInputHandler
    {
        private readonly string[] _args;
        private bool _used;

        public CommandLineInputHandler(string[] args)
        {
            _args = args;
            _used = false;
        }

        public string GetInput()
        {
            if (_used) return string.Empty;
            
            _used = true;
            return string.Join(" ", _args);
        }
    }
}