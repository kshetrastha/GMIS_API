using gmis.Application.Features.Industries.Command.CreateIndustry;
using gmis.Application.Features.Industries.Command.UpdateIndustry;
using gmis.Application.Features.Industries.Queries.GetIndistryById;
using gmis.Application.Features.Industries.Queries.GetIndistryBySearchCriteria;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace gmis.API.Controllers.Industry
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndustriesController : BaseController
    {
        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await Mediator.Send(new GetIndustryListQuery()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return Ok(await Mediator.Send(new GetIndustryByIdQuery(id)));
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateIndustryCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateIndustryCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, [FromBody] DeleteIndustryCommand command)
        {
            if (command.IndustryId == 0)
                command.IndustryId = id;
            return Ok(await Mediator.Send(command));
        }
    }
}
