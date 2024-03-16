using AutoMapper;
using gmis.Application.Common.Model;
using gmis.Application.Contracts.Persistence.Base;
using gmis.Domain.Entities.LineOfBusiness;
using MediatR;

namespace gmis.Application.Features.LOB.Command.UpdateLineOfBusiness
{
    public class UpdateLineOfBuisnessCommandHandler : IRequestHandler<UpdateLineOfBuisnessCommand, ResponseModel<string>>
    {
        private string _message = "Line Of Business Updated Successfully.";

        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        public UpdateLineOfBuisnessCommandHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repository = repositoryManager;
            _mapper = mapper;
        }
        public async Task<ResponseModel<string>> Handle(UpdateLineOfBuisnessCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var data = _mapper.Map<LineOfBusiness>(request);
                _repository.LineOfBusinessRepository.Update(data);
                await _repository.SaveAsync();
                return new ResponseModel<string>()
                {
                    Succeeded = true,
                    Message = _message
                };
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
