using MediatR;
using SimpleCalculatorCsharp.Src.Application.Queries;
using SimpleCalculatorCsharp.Src.Application.DTOs;
using SimpleCalculatorCsharp.Src.Application.Interfaces;

namespace SimpleCalculatorCsharp.Src.Application.Handlers
{
    public class HistoryQueryHandler : IRequestHandler<GetCalculationHistoryQuery, HistoryResultDto>
    {
        private readonly IHistoryService _historyService;

        public HistoryQueryHandler(IHistoryService historyService)
        {
            _historyService = historyService;
        }

        public Task<HistoryResultDto> Handle(GetCalculationHistoryQuery request, CancellationToken cancellationToken)
        {
            var history = _historyService.GetHistory()
                .OrderByDescending(h => h.Timestamp)
                .Take(request.Limit)
                .Select(h => new HistoryEntryDto
                {
                    Expression = h.Expression,
                    Result = h.Result,
                    Timestamp = h.Timestamp
                });

            return Task.FromResult(new HistoryResultDto { Entries = history });
        }
    }
}