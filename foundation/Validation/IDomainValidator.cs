namespace foundation.Validation
{
    public interface IDomainValidator<in T> where T : class
    {
        DomainValidationResult Validate(T subject);

        void ValidateWithException(T subject);
    }
}