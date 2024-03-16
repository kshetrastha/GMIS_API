using gmis.Application.Common.Model;
using MediatR;

namespace gmis.Application.Features.LOB.Command.UpdateLineOfBusiness
{
    public class UpdateLineOfBuisnessCommand : IRequest<ResponseModel<string>>
    {
        public int LineOfBusinessID { get; set; }
        public string LineOfBusinessName { get; set; } = null!;
        public bool IsActive { get; set; }

    }
}
