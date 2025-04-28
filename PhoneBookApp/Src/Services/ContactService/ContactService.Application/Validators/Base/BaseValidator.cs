using FluentValidation;
using System.Text.RegularExpressions;
using System.Linq;
using System.Linq.Expressions;
using System;

namespace ContactService.Application.Validators.Base
{
    public abstract class BaseValidator<T> : AbstractValidator<T>
    {
        protected void ValidateName(Expression<Func<T, string>> nameExpression, string fieldName)
        {
            RuleFor(nameExpression)
                .NotEmpty().WithMessage($"{fieldName} is required.")
                .MaximumLength(100).WithMessage($"{fieldName} must not exceed 100 characters.");
        }

        protected void ValidateContactType(Expression<Func<T, string>> typeExpression)
        {
            RuleFor(typeExpression)
                .NotEmpty().WithMessage("Contact type is required.")
                .Must(type => new[] { "PhoneNumber", "Email", "Location" }.Contains(type))
                .WithMessage("Contact type must be PhoneNumber, Email, or Location.");
        }

        protected void ValidateContent(Expression<Func<T, string>> contentExpression)
        {
            RuleFor(contentExpression)
                .NotEmpty().WithMessage("Content is required.")
                .MaximumLength(255).WithMessage("Content must not exceed 255 characters.");
        }

        protected void ValidateContentByType(Expression<Func<T, string>> typeExpression, Expression<Func<T, string>> contentExpression, Func<string, bool> isCountryExists)
        {
            When(x => typeExpression.Compile()(x) == "Email", () =>
            {
                RuleFor(contentExpression)
                    .EmailAddress()
                    .WithMessage("Invalid email format.");
            });

            When(x => typeExpression.Compile()(x) == "PhoneNumber", () =>
            {
                RuleFor(contentExpression)
                    .Matches(@"^\+?[0-9\s]+$")
                    .WithMessage("Invalid phone number format.");
            });

            When(x => typeExpression.Compile()(x) == "Location", () =>
            {
                RuleFor(contentExpression)
                    .Must(content =>
                    {
                        if (!Guid.TryParse(content, out Guid countryId))
                            return false;

                        return isCountryExists(content);
                    })
                    .WithMessage("Selected location does not correspond to a valid country.");
            });
        }
    }
}
