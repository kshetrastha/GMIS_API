using gmis.Application.Common.Model;
using MediatR;

namespace gmis.Application.Features.Industries.Command.UpdateIndustry
{
    public class UpdateIndustryCommand :IRequest<ResponseModel<string>>
    {
        public int IndustryId { get; set; }
        public string NaicsCode { get; set; } = null!;
        public string? NaicsTitle { get; set; }
        public bool IsActive{ get; set; }
        public bool IsDeleted { get; set; }
    }
    public class DeleteIndustryCommand : IRequest<ResponseModel<string>>
    {
        public int IndustryId { get; set; }
    }
}
