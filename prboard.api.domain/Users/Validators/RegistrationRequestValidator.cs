using System;
using FluentValidation;
using foundation.Entities.Contracts;
using foundation.Validation;
using Microsoft.EntityFrameworkCore;
using prboard.api.data.Countries.Entities;
using prboard.api.data.Users.Entities;
using prboard.api.domain.Users.Requests;

namespace prboard.api.domain.Users.Validators
{
    public class RegistrationRequestValidator : DomainValidator<RegistrationRequest>
    {
        public RegistrationRequestValidator(
            IRepository<UserEntity> userRepository,
            IRepository<CountryEntity> countryRepository
        )
        {
            RuleFor(e => e.Name)
                .NotEmpty()
                .WithMessage("'Name' is required.")
                .MaximumLength(20)
                .WithMessage("'Name' maximum length exceeded - 20 characters max");

            RuleFor(e => e.Email)
                .NotEmpty()
                .WithMessage("'Email' is required.")
                .MaximumLength(40)
                .WithMessage("'Email' maximum length exceeded");

            RuleFor(e => e.Password)
                .NotEmpty()
                .WithMessage("'Password' is required.")
                .MaximumLength(50)
                .WithMessage("'Password' maximum length exceeded - 50 characters max");

            RuleFor(e => e.PasswordConfirm)
                .Must((e, f) => f == e.Password)
                .WithMessage("'Password' and 'Password Confirm' don't match.");

            RuleFor(e => e.Email)
                .MustAsync(async (e, f, c) =>
                {
                    var existing = await userRepository.FirstOrDefaultAsync(p => p.Email == f);

                    return existing == null;
                })
                .WithMessage("Email is already taken.");
        }
    }
}