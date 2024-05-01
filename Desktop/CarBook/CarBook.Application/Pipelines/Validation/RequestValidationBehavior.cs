using FluentValidation;
using MediatR;

namespace CarBook.Application.Pipelines.Validation;

public class RequestValidationBehavior<TRequest , TResponse>: IPipelineBehavior<TRequest , TResponse>
	where TRequest : IRequest<TResponse>,IRequestValidator
{

        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
		var validationContext = new ValidationContext<TRequest>(request);
		var failures = request.Validators.Select(validator => validator.Validate(validationContext))
			.SelectMany(result => result.Errors)
			.Where(failure => failure != null).ToList();

		if (failures.Any()) throw new Exception("Validation Error");

		return next();
        }
    }