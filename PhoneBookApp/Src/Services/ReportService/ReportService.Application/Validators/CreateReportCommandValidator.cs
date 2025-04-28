using FluentValidation;
using ReportService.Application.Features.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportService.Application.Validators
{
    public class CreateReportCommandValidator : AbstractValidator<CreateReportCommand>
    {
        public CreateReportCommandValidator()
        {
            // Şu an CreateReportCommand boş olduğu için validation şartı koymuyoruz.
            // İleride alan eklenirse burada kurallar tanımlanacak.
        }
    }
}
