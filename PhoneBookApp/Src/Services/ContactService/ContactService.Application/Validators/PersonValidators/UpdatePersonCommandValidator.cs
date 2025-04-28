using ContactService.Application.Features.PersonFeatures.Commands;
using ContactService.Application.Validators.Base;
using FluentValidation;

namespace ContactService.Application.Validators.PersonValidators
{
    public class UpdatePersonCommandValidator : BaseValidator<UpdatePersonCommand>
    {
        public UpdatePersonCommandValidator()
        {
            RuleFor(x => x.Person.Id)
                .NotEmpty().WithMessage("Person ID is required.");

            ValidateName(x => x.Person.FirstName, "First Name");
            ValidateName(x => x.Person.LastName, "Last Name");
            ValidateName(x => x.Person.Company, "Company");
        }
    }

}
