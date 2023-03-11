using FluentValidation;
using IpQualityScore.Net.Exceptions;

namespace IpQualityScore.Net.Validators.Common
{
    internal abstract class IpQualityScoreBaseValidator
    {
        protected void ValidateRequest<TRequestValidator, TRequest>(TRequest request)
            where TRequestValidator : AbstractValidator<TRequest>, new()
        {
            var validator = new TRequestValidator();
            var validationResult = validator.Validate(request);
            if (!validationResult.IsValid)
            {
                throw new RequestValidationException(validationResult.Errors.ToDictionary(e => e.PropertyName, e => e.ErrorMessage),
                    $"Error while {typeof(TRequest).Name} validation");
            }
        }
    }
}
