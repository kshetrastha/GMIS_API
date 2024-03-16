using gmis.Application.Features.LOB.Command.CreateLineOfBusiness;
using gmis.Application.Features.LOB.Command.UpdateLineOfBusiness;
using gmis.Application.Features.LOB.Queries.GetPaginatedLOB;
using gmis.Application.Features.LOF.Queries.GetAllListAsync;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace gmis.API.Controllers.LOB
{
    [Route("gmis/api/[controller]")]
    [ApiController]
    public class LOBController : BaseController
    {
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllListQueryAsync()));
        }
        [HttpPost("CreateLOB")]
        public async Task<IActionResult> Create([FromBody] CreateLineOfBusinessCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateLineOfBuisnessCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpPost("GetAllPaginated")]
        public async Task<IActionResult> GetAllPaginated([FromBody]GetLineOfBusinessPaginatedQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}
