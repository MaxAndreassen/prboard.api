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
        public UserEditorValidator()
        {
        }
    }
}