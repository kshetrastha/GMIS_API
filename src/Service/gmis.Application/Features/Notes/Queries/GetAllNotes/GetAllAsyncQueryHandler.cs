using AutoMapper;
using gmis.Application.Common.Model;
using gmis.Application.Contracts.Persistence.Base;
using gmis.Domain.Entities.Notes.DataTransferObjects;
using gmis.Shared.ResponseMessage;
using MediatR;

namespace gmis.Application.Features.Notes.Queries.GetAllNotes
{
    public class GetAllAsyncQueryHandler : IRequestHandler<GetAllAsyncQuery, ResponseModel<List<NotesDtos>>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public GetAllAsyncQueryHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public async Task<ResponseModel<List<NotesDtos>>> Handle(GetAllAsyncQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _repositoryManager.NotesRepository.GetAllAsync(false);
                return new ResponseModel<List<NotesDtos>>(true, MessageConstants.Fetched, _mapper.Map<List<NotesDtos>>(data));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
