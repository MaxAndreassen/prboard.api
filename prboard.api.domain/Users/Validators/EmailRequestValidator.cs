using System.Text.RegularExpressions;
using FluentValidation;
using foundation.Validation;
using prboard.api.domain.Email.Models;

namespace prboard.api.domain.Users.Validators
{
    public class EmailRequestValidator : DomainValidator<EmailRequest>
    {
        private const string EmailRegex = @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
                                          + "@"
                                          + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$";
        
        public EmailRequestValidator()
        {
            RuleFor(p => p.Email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("'Email' is required.")
                .Must(p => Regex.IsMatch(p, EmailRegex))
                .WithMessage("Invalid Email Address.");
        }
    }
}