using FluentValidation;
using SimpleCalculatorCsharp.Src.Application.Commands;

namespace SimpleCalculatorCsharp.Src.Application.Validators
{
    public class CalculateExpressionCommandValidator : AbstractValidator<CalculateExpressionCommand>
    {
        public CalculateExpressionCommandValidator()
        {
            RuleFor(x => x.Expression)
                .NotEmpty().WithMessage("Expression cannot be empty")
                .Must(BeValidExpression).WithMessage("Invalid characters in expression");
        }

        private bool BeValidExpression(string expression)
        {
            var allowedChars = "0123456789+-*/(). ";
            return expression.All(c => allowedChars.Contains(c));
        }
    }
}