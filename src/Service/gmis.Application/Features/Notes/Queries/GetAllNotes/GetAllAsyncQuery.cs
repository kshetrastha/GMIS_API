using gmis.Application.Common.Model;
using gmis.Domain.Entities.Notes.DataTransferObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gmis.Application.Features.Notes.Queries.GetAllNotes
{
    public class GetAllAsyncQuery :IRequest<ResponseModel<List<NotesDtos>>>
    {
    }
}
