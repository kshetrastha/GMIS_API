using FluentValidation;
using gmis.Application.Features.Industries.Command.CreateIndustry;

namespace gmis.Application.Features.Industries.Command.UpdateIndustry
{
    public class UpdateIndustryCommandValidator : AbstractValidator<CreateIndustryCommand>
    {
        public UpdateIndustryCommandValidator()
        {
            RuleFor(p => p.NaicsCode).NotEmpty().NotEqual(p => p.NaicsTitle).WithMessage("Naics code is required");
            RuleFor(p => p.NaicsTitle).NotEmpty().NotEqual(p => p.NaicsCode).WithMessage("Naics title is required");
        }
    }
}
