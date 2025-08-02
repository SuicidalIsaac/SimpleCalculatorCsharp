namespace SimpleCalculatorCsharp.Src.Infrastructure.Calculators
{
    public interface ICalculator
    {
        decimal Calculate(IEnumerable<string> tokens);
    }
}