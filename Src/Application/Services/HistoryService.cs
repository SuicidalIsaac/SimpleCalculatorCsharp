using SimpleCalculatorCsharp.Src.Application.Interfaces;
using SimpleCalculatorCsharp.Src.Application.DTOs;
using SimpleCalculatorCsharp.Src.Infrastructure.Repositories;

namespace SimpleCalculatorCsharp.Src.Application.Services
{
    public class HistoryService : IHistoryService
    {
        private readonly ICalculationHistoryRepository _repository;

        public HistoryService(ICalculationHistoryRepository repository)
        {
            _repository = repository;
        }

        public void AddToHistory(string expression, decimal result)
        {
            _repository.Add(new HistoryItemDto 
            { 
                Expression = expression,
                Result = result,
                Timestamp = DateTime.Now 
            });
        }

        public IEnumerable<HistoryItemDto> GetHistory()
        {
            return _repository.GetAll();
        }
    }
}