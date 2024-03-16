using AutoMapper;
using gmis.Application.Common.Model;
using gmis.Application.Contracts.Persistence.Base;
using gmis.Domain.Entities.Industry;
using gmis.Shared.ResponseMessage;
using MediatR;

namespace gmis.Application.Features.Industries.Command.UpdateIndustry
{
    public class UpdateIndustryCommandHandler : IRequestHandler<UpdateIndustryCommand, ResponseModel<string>>,
        IRequestHandler<DeleteIndustryCommand,ResponseModel<string>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;
        public UpdateIndustryCommandHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public async Task<ResponseModel<string>> Handle(UpdateIndustryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var data = _mapper.Map<Industry>(request);
                _repositoryManager.IndustriesRepository.Update(data);
                await _repositoryManager.SaveAsync();
                return new ResponseModel<string>
                {
                    Succeeded = true,
                    Message = MessageConstants.UpdatedSuccess($"Indestry Naics code: {request.NaicsCode} ")
                };

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ResponseModel<string>> Handle(DeleteIndustryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _repositoryManager.IndustriesRepository.GetByIdAsync(request.IndustryId, false);
                data.IsDeleted = true;
                data.IsActive = false;
                _repositoryManager.IndustriesRepository.Update(data);
                await _repositoryManager.SaveAsync();
                return new ResponseModel<string>
                {
                    Succeeded = true,
                    Message = MessageConstants.Deleted
                };

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
