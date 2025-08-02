namespace SimpleCalculatorCsharp.Src.Application.DTOs
{
    public class CalculationResultDto
    {
        public required string Expression { get; set; } 
        public decimal Result { get; set; }
        public bool IsSuccess { get; set; }
        public required string ErrorMessage { get; set; }
    }
}