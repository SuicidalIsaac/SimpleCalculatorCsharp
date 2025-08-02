using SimpleCalculatorCsharp.Src.Infrastructure.OperationStrategies;

namespace SimpleCalculatorCsharp.Src.Infrastructure.Factories
{
    public interface IOperationStrategyFactory
    {
        IOperationStrategy Create(string operatorSymbol);
    }
}