using System.Collections.Generic;

namespace foundation.Validation
{
    public class DomainValidationResult
    {
        public bool Valid => Errors.Count == 0;
        
        public ICollection<DomainValidationError> Errors { get; private set; } = new List<DomainValidationError>();

        public static DomainValidationResult From(ICollection<DomainValidationError> errors)
        {
            return new DomainValidationResult
            {
                Errors = errors
            };
        }
        
        public static DomainValidationResult From(params DomainValidationError[] errors)
        {
            return new DomainValidationResult
            {
                Errors = errors
            };
        }
    }
}