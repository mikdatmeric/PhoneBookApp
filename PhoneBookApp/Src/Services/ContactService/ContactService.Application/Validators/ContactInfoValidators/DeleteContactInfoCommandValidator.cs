using ContactService.Application.Features.ContactInfoFeatures.Commands;
using FluentValidation;

namespace ContactService.Application.Validators.ContactInfoValidators
{
    public class DeleteContactInfoCommandValidator : AbstractValidator<DeleteContactInfoCommand>
    {
        public DeleteContactInfoCommandValidator()
        {
            RuleFor(x => x.ContactInfoId)
                .NotEmpty().WithMessage("Contact Info ID is required.");
        }
    }

}
