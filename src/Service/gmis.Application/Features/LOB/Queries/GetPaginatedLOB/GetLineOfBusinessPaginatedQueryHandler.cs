using gmis.Application.Common.Model;
using gmis.Application.Contracts.Persistence.Base;
using gmis.Shared.ResponseMessage;
using MediatR;

namespace gmis.Application.Features.LOB.Queries.GetPaginatedLOB
{
    public class GetLineOfBusinessPaginatedQueryHandler : IRequestHandler<GetLineOfBusinessPaginatedQuery, ResponseModel<LineOfBusinessPaginatedDto>>
    {
        private readonly IRepositoryManager _repository;
        public GetLineOfBusinessPaginatedQueryHandler(IRepositoryManager repository)
        {
            _repository = repository;
        }
        public async Task<ResponseModel<LineOfBusinessPaginatedDto>> Handle(GetLineOfBusinessPaginatedQuery request, CancellationToken cancellationToken)
        {
            var response = await _repository.LineOfBusinessRepository.GetLobPaginatedAsync(request);
            return new ResponseModel<LineOfBusinessPaginatedDto>
            {
                Succeeded = true,
                Data = response,
                Message = MessageConstants.Fetched
            };
        }
    }
}
