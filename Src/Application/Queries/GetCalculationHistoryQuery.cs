using MediatR;
using SimpleCalculatorCsharp.Src.Application.DTOs;

namespace SimpleCalculatorCsharp.Src.Application.Queries
{
    public class GetCalculationHistoryQuery(int limit = 10) : IRequest<HistoryResultDto>
    {
        public int Limit { get; } = limit;
    }
}