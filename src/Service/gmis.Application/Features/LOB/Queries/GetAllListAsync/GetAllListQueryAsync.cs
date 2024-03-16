using gmis.Application.Common.Model;
using gmis.Application.Features.LOF.Queries.GetAllListAsync.Model;
using MediatR;

namespace gmis.Application.Features.LOF.Queries.GetAllListAsync
{
    public class GetAllListQueryAsync: IRequest<ResponseModel<List<LineOfBusinessModel>>>
    {
    }
}
