using AspirePoc.Core.UseCases.Management.RebuildBookReadModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AspirePoc.UI.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ManagementController(IMediator _mediator) : Controller
    {
        [HttpPost]
        [Route("rebuild-book-readmodel")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(RebuildBookReadModelResponse))]
        public async Task<IActionResult> PublishCategory([FromBody] RebuildBookReadModelRequest request)
        {
            return Ok(await _mediator.Send(request));
        }
    }
}
