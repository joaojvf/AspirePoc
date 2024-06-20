using AspirePoc.Core.UseCases.Categories.GetCategories;
using AspirePoc.Core.UseCases.Categories.PublishCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AspirePoc.UI.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController(IMediator _mediator) : Controller
    {
        [HttpGet]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetCategoriesResponse))]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetCategoriesRequest()));
        }

        [HttpPost]
        [Route("publishCategory")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(PublishCategoryResponse))]
        public async Task<IActionResult> PublishCategory([FromBody] PublishCategoryRequest request)
        {
            return Ok(await _mediator.Send(request));
        }
    }
}
