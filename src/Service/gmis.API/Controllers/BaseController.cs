using gmis.Application.Common.Model;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace gmis.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private ISender _mediator = null!;
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

        protected IActionResult Success<T>(T data, string message = null)
        {
            var response = new ResponseModel<T>
            {
                Succeeded = true,
                Message = message ?? string.Empty,
                Errors = null,
                Data = data
            };

            return Ok(response);
        }
        protected IActionResult Error(string[] errors, string message = null)
        {
            var response = new ResponseModel<object>
            {
                Succeeded = false,
                Message = message ?? "Request processing failed.",
                Errors = errors,
                Data = null
            };

            return BadRequest(response);
        }
        protected string GetOriginFromRequest() => $"{Request.Scheme}://{Request.Host.Value}{Request.PathBase.Value}";

    }
}
