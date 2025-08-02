using Microsoft.Extensions.Logging;
using SimpleCalculatorCsharp.Src.Application.Interfaces;
using SimpleCalculatorCsharp.Src.Infrastructure.Parsers;
using SimpleCalculatorCsharp.Src.Infrastructure.Calculators;

namespace SimpleCalculatorCsharp.Src.Application.Services
{
    public class CalculationService : ICalculationService
    {
        private readonly IExpressionParser _parser;
        private readonly ICalculator _calculator;
        private readonly ILogger<CalculationService> _logger;

        public CalculationService(
            IExpressionParser parser, 
            ICalculator calculator,
            ILogger<CalculationService> logger)
        {
            _parser = parser;
            _calculator = calculator;
            _logger = logger;
        }

        public decimal Calculate(string expression)
        {
            _logger.LogInformation($"Calculating expression: '{expression}'");
            
            try
            {
                var tokens = _parser.Parse(expression);
                _logger.LogInformation($"Parsed tokens: [{string.Join(", ", tokens)}]");
                
                var result = _calculator.Calculate(tokens);
                _logger.LogInformation($"Calculation result: {result}");
                
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Calculation failed for expression: '{expression}'");
                throw;
            }
        }
    }
}