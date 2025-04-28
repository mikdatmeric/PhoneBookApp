using ContactService.Application.Features.PersonFeatures.Commands;
using FluentValidation;

namespace ContactService.Application.Validators.PersonValidators
{
    public class DeletePersonCommandValidator : AbstractValidator<DeletePersonCommand>
    {
        public DeletePersonCommandValidator()
        {
            RuleFor(x => x.PersonId)
                .NotEmpty().WithMessage("Person ID is required.");
        }
    }

}
