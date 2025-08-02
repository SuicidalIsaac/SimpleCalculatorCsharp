namespace SimpleCalculatorCsharp.Src.Presentation.Console.Views
{
    public class ConsoleView : IConsoleView
    {
        public void PrintLine(string message)
        {
            System.Console.WriteLine(message);
        }

        public void Print(string message)
        {
            System.Console.Write(message);
        }

        public string Input()
        {
            return System.Console.ReadLine()!;
        }
    }
}