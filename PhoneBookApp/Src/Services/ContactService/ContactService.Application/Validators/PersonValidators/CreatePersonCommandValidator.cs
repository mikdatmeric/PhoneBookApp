using ContactService.Application.Features.PersonFeatures.Commands;
using ContactService.Application.Validators.Base;

namespace ContactService.Application.Validators.PersonValidators
{
    public class CreatePersonCommandValidator : BaseValidator<CreatePersonCommand>
    {
        public CreatePersonCommandValidator()
        {
            ValidateName(x => x.Person.FirstName, "First Name");
            ValidateName(x => x.Person.LastName, "Last Name");
            ValidateName(x => x.Person.Company, "Company");
        }
    }
}
