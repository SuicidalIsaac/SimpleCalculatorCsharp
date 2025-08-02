using Microsoft.Extensions.Logging;
using SimpleCalculatorCsharp.Src.Infrastructure.Factories;
using System.Globalization;

namespace SimpleCalculatorCsharp.Src.Infrastructure.Calculators
{
    public class RPNCalculator : ICalculator
    {
        private readonly IOperationStrategyFactory _strategyFactory;
        private readonly ILogger<RPNCalculator> _logger;

        public RPNCalculator(
            IOperationStrategyFactory strategyFactory,
            ILogger<RPNCalculator> logger)
        {
            _strategyFactory = strategyFactory;
            _logger = logger;
        }

        public decimal Calculate(IEnumerable<string> tokens)
{
    var stack = new Stack<decimal>();
    
    foreach (var token in tokens)
    {
        if (decimal.TryParse(token, NumberStyles.Any, CultureInfo.InvariantCulture, out var number))
        {
            stack.Push(number);
        }
        else if (token == "u-")
        {
            var operand = stack.Pop();
            stack.Push(-operand);
        }
        else
        {
            var right = stack.Pop();
            var left = stack.Pop();
            
            if (token == "-" && stack.Count > 0)
            {
                var operation = _strategyFactory.Create(token);
                stack.Push(operation.Execute(left, right));
            }
            else
            {
                var operation = _strategyFactory.Create(token);
                stack.Push(operation.Execute(left, right));
            }
        }
    }

    return stack.Pop();
}
    }
}