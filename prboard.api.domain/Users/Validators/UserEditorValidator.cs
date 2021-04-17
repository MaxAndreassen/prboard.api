using FluentValidation;
using foundation.Entities.Contracts;
using foundation.Validation;
using Microsoft.EntityFrameworkCore;
using prboard.api.data.Users.Entities;
using prboard.api.domain.Users.Models;

namespace prboard.api.domain.Users.Validators
{
    public class UserEditorValidator : DomainValidator<UserEditor>
    {
        public UserEditorValidator(IRepository<UserEntity> userRepository)
        {
            RuleFor(e => e.Username)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("'Username' is required.")
                .Must(e => e.Length < 14)
                .WithMessage("'Username' must be less than 14 characters")
                .MustAsync(async (e, f, c) =>
                {
                    var existing = await userRepository.FirstOrDefaultAsync(p => p.Username == f && e.Uuid != p.Uuid);

                    return existing == null;
                })
                .WithMessage("Username is already taken.");
        }
    }
}