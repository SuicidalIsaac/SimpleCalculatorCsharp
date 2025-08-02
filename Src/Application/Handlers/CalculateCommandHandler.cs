using MediatR;
using SimpleCalculatorCsharp.Src.Application.Commands;
using SimpleCalculatorCsharp.Src.Application.DTOs;
using SimpleCalculatorCsharp.Src.Application.Interfaces;

namespace SimpleCalculatorCsharp.Src.Application.Handlers
{
    public class CalculateCommandHandler : IRequestHandler<CalculateExpressionCommand, CalculationResultDto>
    {
        private readonly ICalculationService _calculationService;
        private readonly IHistoryService _historyService;

        public CalculateCommandHandler(
            ICalculationService calculationService,
            IHistoryService historyService)
        {
            _calculationService = calculationService;
            _historyService = historyService;
        }

        public Task<CalculationResultDto> Handle(CalculateExpressionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _calculationService.Calculate(request.Expression);
                _historyService.AddToHistory(request.Expression, result);

                return Task.FromResult(new CalculationResultDto
                {
                    Expression = request.Expression,
                    Result = result,
                    IsSuccess = true,
                    ErrorMessage = ""
                });
            }
            catch (Exception ex)
            {
                return Task.FromResult(new CalculationResultDto
                {
                    Expression = request.Expression,
                    IsSuccess = false,
                    ErrorMessage = $"Calculation error: {ex.Message}"
                });
            }
        }
    }
}