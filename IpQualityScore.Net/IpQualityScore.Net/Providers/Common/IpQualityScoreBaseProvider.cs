using FluentValidation;
using IpQualityScore.Net.Exceptions;

namespace IpQualityScore.Net.Providers.Common
{
	internal abstract class IpQualityScoreBaseProvider
	{
		protected void ValidateRequest<TRequestValidator, TRequest>(TRequest request)
			where TRequestValidator : AbstractValidator<TRequest>, new()
		{
			var validator = new TRequestValidator();
			var validationResult = validator.Validate(request);
			if (!validationResult.IsValid)
			{
				throw new RequestValidationException(validationResult.Errors.ToDictionary(e => e.PropertyName, e => e.ErrorMessage),
					$"Error while {nameof(TRequest)} validation");
			}
		}
	}
}
