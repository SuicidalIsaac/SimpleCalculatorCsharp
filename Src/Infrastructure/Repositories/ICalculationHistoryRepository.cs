using SimpleCalculatorCsharp.Src.Application.DTOs;

namespace SimpleCalculatorCsharp.Src.Infrastructure.Repositories
{
    public interface ICalculationHistoryRepository
    {
        void Add(HistoryItemDto item);
        IEnumerable<HistoryItemDto> GetAll();
    }
}