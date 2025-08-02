namespace SimpleCalculatorCsharp.Src.Infrastructure.OperationStrategies
{
    public interface IOperationStrategy
    {
        decimal Execute(decimal left, decimal right);
    }
}