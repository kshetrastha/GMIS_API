using AutoMapper;
using gmis.Application.Common.Model;
using gmis.Application.Contracts.Persistence.Base;
using gmis.Application.Features.LOF.Queries.GetAllListAsync.Model;
using gmis.Shared.ResponseMessage;
using MediatR;

namespace gmis.Application.Features.LOF.Queries.GetAllListAsync
{
    public class GetAllListQueryHandler : IRequestHandler<GetAllListQueryAsync, ResponseModel<List<LineOfBusinessModel>>>
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        public GetAllListQueryHandler(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ResponseModel<List<LineOfBusinessModel>>> Handle(GetAllListQueryAsync request, CancellationToken cancellationToken)
        {
            var lof = new List<LineOfBusinessModel>();
            var response = await _repository.LineOfBusinessRepository.GetAllAsync();
            if (response is not null && response.Count > 0)
            {
                //lof = _mapper.Map<List<LineOfBusinessModel>>(response);
                lof = response.Select(x => new LineOfBusinessModel()
                {
                    LineOfBusinessID = x.LineOfBusinessID,
                    LineOfBusinessName = x.LineOfBusinessName,
                    CreatedBy = x.CreatedBy,
                    CreatedDate = x.CreatedDate,
                    ModifiedBy = x.ModifiedBy,
                    ModifiedDate = x.ModifiedDate,
                }).ToList();
            }
            return new ResponseModel<List<LineOfBusinessModel>>(true, MessageConstants.Fetched, lof);
        }
    }
}
