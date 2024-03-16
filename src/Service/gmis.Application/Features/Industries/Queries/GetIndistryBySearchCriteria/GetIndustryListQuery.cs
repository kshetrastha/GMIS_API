using gmis.Application.Common.Model;
using gmis.Domain.Entities.Industry.DataTransferObjects;
using MediatR;

namespace gmis.Application.Features.Industries.Queries.GetIndistryBySearchCriteria
{
    public class GetIndustryListQuery :IRequest<ResponseModel<List<IndustriesDto>>>
    {
    }
}
