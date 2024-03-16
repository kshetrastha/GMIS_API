using gmis.Application.Features.LOB.Queries.GetPaginatedLOB;
using gmis.Domain.Entities.LineOfBusiness;

namespace gmis.Application.Contracts.Persistence
{
    public interface ILineOfBusinessRepository
    {
        void Create(LineOfBusiness model);
        void Update(LineOfBusiness model);
        Task<List<LineOfBusiness>> GetAllAsync();
        Task<LineOfBusinessPaginatedDto> GetLobPaginatedAsync(GetLineOfBusinessPaginatedQuery query);
    }
}
