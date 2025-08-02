namespace SimpleCalculatorCsharp.Src.Infrastructure.OperationStrategies
{
    public class AddOperationStrategy : IOperationStrategy
    {
        public decimal Execute(decimal left, decimal right) => left + right;
    }
}