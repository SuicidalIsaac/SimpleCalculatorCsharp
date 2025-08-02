using FluentValidation;
using SimpleCalculatorCsharp.Src.Application.Queries;

namespace SimpleCalculatorCsharp.Src.Application.Validators
{
    public class GetCalculationHistoryQueryValidator : AbstractValidator<GetCalculationHistoryQuery>
    {
        public GetCalculationHistoryQueryValidator()
        {
            RuleFor(x => x.Limit)
                .GreaterThan(0).WithMessage("Limit must be greater than 0")
                .LessThanOrEqualTo(100).WithMessage("Limit cannot exceed 100");
        }
    }
}