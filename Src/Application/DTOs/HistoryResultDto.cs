namespace SimpleCalculatorCsharp.Src.Application.DTOs
{
    public class HistoryResultDto
    {
        public required IEnumerable<HistoryEntryDto> Entries { get; set; }
    }
}