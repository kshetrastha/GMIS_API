using AutoMapper;
using gmis.Application.Common.Model;
using gmis.Application.Contracts.Persistence.Base;
using gmis.Domain.Entities.Industry;
using gmis.Shared.ResponseMessage;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gmis.Application.Features.Industries.Command.CreateIndustry
{
    public class CreateIndustryCommandHandler : IRequestHandler<CreateIndustryCommand, ResponseModel<string>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;
        public CreateIndustryCommandHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public async Task<ResponseModel<string>> Handle(CreateIndustryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var data  = _mapper.Map<Industry>(request);
                _repositoryManager.IndustriesRepository.Create(data);
                await _repositoryManager.SaveAsync();
                return new ResponseModel<string> { Succeeded = true,
                    Message  = MessageConstants.CreatedSuccess($"Indestry Naics code: {request.NaicsCode } ") };

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
