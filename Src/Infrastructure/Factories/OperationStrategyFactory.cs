using SimpleCalculatorCsharp.Src.Infrastructure.OperationStrategies;

namespace SimpleCalculatorCsharp.Src.Infrastructure.Factories
{
    public class OperationStrategyFactory : IOperationStrategyFactory
    {
        private readonly Dictionary<string, IOperationStrategy> _strategies;

        public OperationStrategyFactory(
            AddOperationStrategy add,
            SubtractOperationStrategy subtract,
            MultiplyOperationStrategy multiply,
            DivideOperationStrategy divide)
        {
            _strategies = new Dictionary<string, IOperationStrategy>(StringComparer.OrdinalIgnoreCase)
            {
                ["+"] = add,
                ["-"] = subtract,
                ["*"] = multiply,
                ["/"] = divide,
            };
        }

        public IOperationStrategy Create(string operatorSymbol)
{
    // Обработка унарного минуса
    if (operatorSymbol.StartsWith("-") && operatorSymbol.Length > 1)
    {
        return _strategies["-"];
    }
    
    if (_strategies.TryGetValue(operatorSymbol, out var strategy))
    {
        return strategy;
    }

    throw new KeyNotFoundException($"Operator '{operatorSymbol}' not supported");
}
    }
}