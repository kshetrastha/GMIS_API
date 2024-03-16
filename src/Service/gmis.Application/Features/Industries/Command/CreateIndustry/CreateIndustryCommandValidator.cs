using FluentValidation;

namespace gmis.Application.Features.Industries.Command.CreateIndustry
{
    public class CreateIndustryCommandValidator : AbstractValidator<CreateIndustryCommand>
    {
        public CreateIndustryCommandValidator()
        {
            RuleFor(p => p.NaicsCode).NotEmpty().NotEqual(p => p.NaicsTitle).WithMessage("Naics code is required");
            RuleFor(p => p.NaicsTitle).NotEmpty().NotEqual(p => p.NaicsCode).WithMessage("Naics title is required");
        }
    }
}
