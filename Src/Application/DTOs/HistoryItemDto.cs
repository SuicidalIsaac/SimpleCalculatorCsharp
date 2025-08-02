namespace SimpleCalculatorCsharp.Src.Application.DTOs
{
    public class HistoryItemDto
    {
        public string Expression { get; set; } = "";
        public decimal Result { get; set; }
        public DateTime Timestamp { get; set; }
    }
}