using FluentValidation;
using foundation.Validation;
using prboard.api.domain.Users.Requests;

namespace prboard.api.domain.Users.Validators
{
    public class PasswordResetRequestValidator : DomainValidator<PasswordResetRequest>
    {
        public PasswordResetRequestValidator()
        {
            RuleFor(e => e.Password)
                .NotEmpty()
                .WithMessage("'Password' is required.");

            RuleFor(e => e.PasswordConfirm)
                .NotEmpty()
                .WithMessage("'Password Confirm' is required.");

            RuleFor(e => e.Password)
                .Must((e, f) => e.Password == e.PasswordConfirm)
                .WithMessage("'Password' and 'Password Confirm' must match.");
        }
    }
}