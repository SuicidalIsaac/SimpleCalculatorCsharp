namespace SimpleCalculatorCsharp.Src.Presentation.Console.Views
{
    public interface IConsoleView
    {
        void PrintLine(string message);
        void Print(string message);
        string Input();
    }
}