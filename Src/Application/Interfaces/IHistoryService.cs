using SimpleCalculatorCsharp.Src.Application.DTOs;

namespace SimpleCalculatorCsharp.Src.Application.Interfaces
{
    public interface IHistoryService
    {
        void AddToHistory(string expression, decimal result);
        IEnumerable<HistoryItemDto> GetHistory();
    }
}