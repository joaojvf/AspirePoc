using AspirePoc.Core.UseCases.Books.AddBook;
using AspirePoc.Core.UseCases.Books.GetBookById;
using AspirePoc.Core.UseCases.Books.GetBooks;
using AspirePoc.Core.UseCases.Books.UpdateBook;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AspirePoc.UI.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController(IMediator _mediator) : Controller
    {
        [HttpGet]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetBooksResponse))]
        public async Task<IActionResult> GetBooks([FromQuery] GetBooksRequest request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetByIdBookResponse))]
        public async Task<IActionResult> GetBookById([FromRoute] int id)
        {
            return Ok(await _mediator.Send(new GetByIdBookRequest(id)));
        }

        [HttpPost]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AddBookResponse))]
        public async Task<IActionResult> AddNewBook(AddBookRequest request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UpdateBookResponse))]
        public async Task<IActionResult> UpdateBook([FromRoute] int id, [FromBody] UpdateBookRequest request)
        {
            return Ok(await _mediator.Send(request));
        }
    }
}
