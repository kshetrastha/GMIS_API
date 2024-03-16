using AutoMapper;
using gmis.Application.Common.Model;
using gmis.Application.Contracts.Persistence.Base;
using gmis.Application.Exceptions;
using gmis.Application.Features.Industries.Queries.GetIndistryById;
using gmis.Domain.Entities.Industry.DataTransferObjects;
using gmis.Shared.ResponseMessage;
using MediatR;

namespace gmis.Application.Features.Industries.Queries.GetIndistryBySearchCriteria
{

    public class GetIndustriesBySearchCriteriaQueryHandler :
        IRequestHandler<GetIndustryByIdQuery, ResponseModel<IndustriesDto>>,
        IRequestHandler<GetIndustryListQuery, ResponseModel<List<IndustriesDto>>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public GetIndustriesBySearchCriteriaQueryHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public async Task<ResponseModel<List<IndustriesDto>>> Handle(GetIndustryListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _repositoryManager.IndustriesRepository.GetAllAsync(false);
                if (response is null)
                {
                    throw new NotFoundException("Industry does not found");
                }
                return new ResponseModel<List<IndustriesDto>>(true, MessageConstants.Fetched, _mapper.Map<List<IndustriesDto>>(response));
            }
            catch
            {

                throw;/* new InternalServerException(500, "Unknown error occurred. Please try again later.");*/
            }
        }

        public async Task<ResponseModel<IndustriesDto>> Handle(GetIndustryByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _repositoryManager.IndustriesRepository.GetByIdAsync(request.IndustryId, false);
                if (response is null)
                    throw new NotFoundException($"Industry with id {request.IndustryId} does not found");
                return new ResponseModel<IndustriesDto>(true, MessageConstants.Fetched, _mapper.Map<IndustriesDto>(response));
            }
            catch
            {

                throw new InternalServerException(500, "Unknown error occurred. Please try again later.");
            }
        }
    }
}
