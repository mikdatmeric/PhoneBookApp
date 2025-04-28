using ContactService.Application.Features.ContactInfoFeatures.Commands;
using ContactService.Application.Services.Abstract;
using ContactService.Application.Validators.Base;

namespace ContactService.Application.Validators.ContactInfoValidators
{
    public class CreateContactInfoCommandValidator : BaseValidator<CreateContactInfoCommand>
    {
        public CreateContactInfoCommandValidator(ICountryService countryService)
        {
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
