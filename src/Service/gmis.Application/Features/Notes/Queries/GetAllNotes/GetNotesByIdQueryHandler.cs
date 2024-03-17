using AutoMapper;
using gmis.Application.Common.Model;
using gmis.Application.Contracts.Persistence.Base;
using gmis.Domain.Entities.Notes.DataTransferObjects;
using gmis.Shared.ResponseMessage;
using MediatR;

namespace gmis.Application.Features.Notes.Queries.GetAllNotes
{
    public class GetNotesByIdQueryHandler : IRequestHandler<GetNotesByIdQuery, ResponseModel<NotesDtos>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public GetNotesByIdQueryHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public async Task<ResponseModel<NotesDtos>> Handle(GetNotesByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _repositoryManager.NotesRepository.GetByIdAsync(request.Id, false);
                return new ResponseModel<NotesDtos>(true, MessageConstants.Fetched, _mapper.Map<NotesDtos>(data));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
