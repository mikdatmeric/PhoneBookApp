using ContactService.Application.Features.ContactInfoFeatures.Commands;
using ContactService.Application.Services.Abstract;
using ContactService.Application.Validators.Base;
using FluentValidation;

namespace ContactService.Application.Validators.ContactInfoValidators
{
    public class UpdateContactInfoCommandValidator : BaseValidator<UpdateContactInfoCommand>
    {
        public UpdateContactInfoCommandValidator(ICountryService countryService)
        {
            RuleFor(x => x.ContactInfo.Id)
                .NotEmpty().WithMessage("Contact Info ID is required.");

            ValidateContactType(x => x.ContactInfo.Type);
            ValidateContent(x => x.ContactInfo.Content);
            ValidateContentByType(
                x => x.ContactInfo.Type,
                x => x.ContactInfo.Content,
                content =>
                {
                    if (!Guid.TryParse(content, out var id)) return false;
                    return countryService.CheckCountryExists(id);
                });
        }
    }

}
