using AutoMapper;
using gmis.Application.Common.Model;
using gmis.Application.Contracts.Persistence.Base;
using gmis.Domain.Entities.LineOfBusiness;
using gmis.Shared.ResponseMessage;
using MediatR;

namespace gmis.Application.Features.LOB.Command.CreateLineOfBusiness
{
    public class CreateLineOfBusinessCommandHandler : IRequestHandler<CreateLineOfBusinessCommand, ResponseModel<string>>
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        public CreateLineOfBusinessCommandHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repositoryManager;
        }
        public async Task<ResponseModel<string>> Handle(CreateLineOfBusinessCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var data = _mapper.Map<LineOfBusiness>(request);
                _repository.LineOfBusinessRepository.Create(data);
                await _repository.SaveAsync();
                return new ResponseModel<string>
                {
                    Succeeded = true,
                    Message = MessageConstants.CreatedSuccess("Line Of Business")
                };
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
