namespace SimpleCalculatorCsharp.Src.Infrastructure.Parsers
{
    public interface IExpressionParser
    {
        IEnumerable<string> Parse(string expression);
    }
}