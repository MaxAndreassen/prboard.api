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
            RuleFor(e => e.FirstName)
                .Must((e, f) =>
                {
                    if (e.IsBusiness)
                        return true;

                    return !string.IsNullOrEmpty(f);
                })
                .WithMessage("'First Name' is required.")
                .MaximumLength(20)
                .WithMessage("'First Name' maximum length exceeded");

            RuleFor(e => e.LastName)
                .Must((e, f) =>
                {
                    if (e.IsBusiness)
                        return true;

                    return !string.IsNullOrEmpty(f);
                })
                .WithMessage("'Last Name' is required.")
                .MaximumLength(20)
                .WithMessage("'Last Name' maximum length exceeded");

            RuleFor(e => e.CompanyName)
                .Must((e, f) =>
                {
                    if (!e.IsBusiness)
                        return true;

                    return !string.IsNullOrEmpty(f);
                })
                .WithMessage("'Company Name' is required.")
                .MaximumLength(30)
                .WithMessage("'Company Name' maximum length exceeded");

            RuleFor(e => e.DateOfBirth)
                .Cascade(CascadeMode.Stop)
                .Must((e, f) =>
                {
                    if (e.IsSilent)
                        return true;

                    return e.DateOfBirth != null;
                })
                .WithMessage("'Date of Birth' is required.")
                .Must((e, f) =>
                {
                    if (e.IsSilent)
                        return true;
                    
                    return f != null && f.Value.AddYears(18) < DateTime.Now;
                })
                .WithMessage("You must be at least 18 years old.");

            RuleFor(e => e.Email)
                .NotEmpty()
                .WithMessage("'Email' is required.")
                .MaximumLength(40)
                .WithMessage("'Email' maximum length exceeded");

            RuleFor(e => e.Password)
                .Must((e, f) =>
                {
                    if (e.IsSilent)
                        return true;

                    return !string.IsNullOrEmpty(e.Password);
                })
                .WithMessage("'Password' is required.")
                .MaximumLength(50)
                .WithMessage("'Password' maximum length exceeded");

            RuleFor(e => e.Username)
                .Must((e, f) =>
                {
                    if (e.IsSilent)
                        return true;

                    return !string.IsNullOrEmpty(e.Username);
                })
                .WithMessage("'Username' is required.")
                .MaximumLength(14)
                .WithMessage("'Username' must be less than 14 characters");

            RuleFor(e => e.PasswordConfirm)
                .Must((e, f) => f == e.Password)
                .WithMessage("'Password' and 'Password Confirm' don't match.")
                .MaximumLength(50)
                .WithMessage("'Password Confirm' maximum length exceeded");

            RuleFor(e => e.CountryUuid)
                .MustAsync(async (e, f, c) =>
                {
                    if (e.IsSilent)
                        return true;
                    
                    var country = await countryRepository.FirstOrDefaultAsync(p => p.Uuid == f);

                    return country != null;
                })
                .WithMessage("'Country' is required");

            RuleFor(e => e.Username)
                .MustAsync(async (e, f, c) =>
                {
                    if (e.IsSilent)
                        return true;
                    
                    var existing = await userRepository.FirstOrDefaultAsync(p => p.Username == f);

                    return existing == null;
                })
                .WithMessage("Username is already taken.");

            RuleFor(e => e.Email)
                .MustAsync(async (e, f, c) =>
                {
                    var existing = await userRepository.FirstOrDefaultAsync(p => p.Email == f);

                    return existing == null;
                })
                .WithMessage("Email is already taken.");

            RuleFor(p => p.AffiliateUserUuid)
                .MustAsync(async (e, f, c) =>
                {
                    if (f == null)
                        return true;

                    var affiliate = await userRepository.FirstOrDefaultAsync(p => p.Uuid == f);

                    return affiliate.StripeAccountId != null;
                })
                .WithMessage(
                    "The account attached to this affiliate link has not completed their on-boarding process. You cannot register an account affiliated with them until they do this.");
        }
    }
}