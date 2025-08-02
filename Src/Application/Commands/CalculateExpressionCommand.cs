using MediatR;
using SimpleCalculatorCsharp.Src.Application.DTOs;

namespace SimpleCalculatorCsharp.Src.Application.Commands
{
    public class CalculateExpressionCommand(string expression) : IRequest<CalculationResultDto>
    {
        public string Expression { get; } = expression;
    }
}