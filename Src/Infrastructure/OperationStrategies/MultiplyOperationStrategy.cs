namespace SimpleCalculatorCsharp.Src.Infrastructure.OperationStrategies
{
    public class MultiplyOperationStrategy : IOperationStrategy
    {
        public decimal Execute(decimal left, decimal right) => left * right;
    }
}