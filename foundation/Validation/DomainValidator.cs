using FluentValidation;

namespace foundation.Validation
{
    public abstract class DomainValidator<T> : AbstractValidator<T>, IDomainValidator<T> where T : class 
    {
        DomainValidationResult IDomainValidator<T>.Validate(T subject)
        {
            var result = Validate(subject);
            
            var domainResult = new DomainValidationResult();

            foreach (var err in result.Errors)
            {
                domainResult.Errors.Add(new DomainValidationError
                {
                    PropertyName = err.PropertyName,
                    Message = err.ErrorMessage
                });
            }

            return domainResult;
        }

        public void ValidateWithException(T subject)
        {
            var result = Validate(subject);
            
            if (!result.IsValid)
                throw new ValidationException(result.Errors);
        }
    }
}