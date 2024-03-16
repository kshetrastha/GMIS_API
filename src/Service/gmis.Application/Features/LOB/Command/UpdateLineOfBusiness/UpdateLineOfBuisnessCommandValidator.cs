using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gmis.Application.Features.LOB.Command.UpdateLineOfBusiness
{
    public class UpdateLineOfBuisnessCommandValidator : AbstractValidator<UpdateLineOfBuisnessCommand>
    {
        public UpdateLineOfBuisnessCommandValidator()
        {
            RuleFor(p => p.LineOfBusinessName)
               .NotEmpty()
               .WithMessage("{LineOfBusinessName} is required");
        }
    }
}
