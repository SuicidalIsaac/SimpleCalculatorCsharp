namespace SimpleCalculatorCsharp.Src.Infrastructure.OperationStrategies
{
    public class SubtractOperationStrategy : IOperationStrategy
    {
        public decimal Execute(decimal left, decimal right) => left - right;
    }
}