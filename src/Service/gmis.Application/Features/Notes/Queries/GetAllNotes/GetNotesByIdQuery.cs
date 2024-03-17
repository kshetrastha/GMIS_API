using gmis.Application.Common.Model;
using gmis.Domain.Entities.Notes.DataTransferObjects;
using MediatR;

namespace gmis.Application.Features.Notes.Queries.GetAllNotes
{
    public class GetNotesByIdQuery : IRequest<ResponseModel<NotesDtos>>
    {
        public int Id { get; set; }
        public GetNotesByIdQuery(int id)
        {
            this.Id = id;
        }
    }
}
