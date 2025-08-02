namespace SimpleCalculatorCsharp.Src.Domain.Exceptions
{
    public class CalculationException : Exception
    {
        public CalculationException(string message) : base(message) { }
    }
}