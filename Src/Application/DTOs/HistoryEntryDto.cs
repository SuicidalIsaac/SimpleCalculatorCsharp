namespace SimpleCalculatorCsharp.Src.Application.DTOs
{
    public class HistoryEntryDto
    {
        public required string Expression { get; set; }
        public decimal Result { get; set; }
        public DateTime Timestamp { get; set; }
    }
}