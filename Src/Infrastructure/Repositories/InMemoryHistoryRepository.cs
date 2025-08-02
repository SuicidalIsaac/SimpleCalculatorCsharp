using SimpleCalculatorCsharp.Src.Application.DTOs;

namespace SimpleCalculatorCsharp.Src.Infrastructure.Repositories
{
    public class InMemoryHistoryRepository : ICalculationHistoryRepository
    {
        private readonly List<HistoryItemDto> _history = [];

        public void Add(HistoryItemDto item)
        {
            _history.Add(item);
        }

        public IEnumerable<HistoryItemDto> GetAll()
        {
            return _history.AsEnumerable();
        }
    }
}