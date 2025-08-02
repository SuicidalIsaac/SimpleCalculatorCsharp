using FluentValidation;
using MediatR;

namespace SimpleCalculatorCsharp.Src.Application.Pipelines
{
    public class ValidationPipelineBehavior<TRequest, TResponse>(IValidator<TRequest> validator) : IPipelineBehavior<TRequest, TResponse>
        where TRequest : notnull
    {
        private readonly IValidator<TRequest> _validator = validator;

        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var result = _validator.Validate(request);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
            
            return Task.FromResult(next(cancellationToken).GetAwaiter().GetResult());
        }
    }
}