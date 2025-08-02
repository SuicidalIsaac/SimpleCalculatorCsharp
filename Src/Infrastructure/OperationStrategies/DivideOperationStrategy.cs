using SimpleCalculatorCsharp.Src.Domain.Exceptions;

namespace SimpleCalculatorCsharp.Src.Infrastructure.OperationStrategies
{
    public class DivideOperationStrategy : IOperationStrategy
    {
        public decimal Execute(decimal left, decimal right)
        {
            if (right == 0) throw new CalculationException("Division by zero");
            return left / right;
        }
    }
}