using gmis.Application.Features.Notes.Queries.GetAllNotes;
using Microsoft.AspNetCore.Mvc;

namespace gmis.API.Controllers.Notes
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : BaseController
    {
        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await Mediator.Send(new GetAllAsyncQuery()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNoteById(int id)
        {
            return Ok(await Mediator.Send(new GetNotesByIdQuery(id)));
        }
    }
}
