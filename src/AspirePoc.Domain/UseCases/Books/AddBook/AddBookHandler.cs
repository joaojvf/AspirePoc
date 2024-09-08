using AspirePoc.Core.Abstractions.Repositories;
using AspirePoc.Core.Entities;
using AspirePoc.Core.Events;
using AspirePoc.Core.Exceptions;
using FluentValidation;
using MediatR;

namespace AspirePoc.Core.UseCases.Books.AddBook
{
    public class AddBookHandler(
        IMediator _mediator,
       IValidator<AddBookRequest> _validator,
       IBookRepository _bookRepository) : IRequestHandler<AddBookRequest, AddBookResponse>
    {
        public async Task<AddBookResponse> Handle(AddBookRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new FluentValidationException(validationResult);
            }

            var book = new Book
            {
                Tittle = request.Tittle,
                AuthorName = request.AuthorName,
                Description = request.Description,
                ReleaseDate = request.ReleaseDate,
                CategoryId = request.CategoryId,
            };

            var res = await _bookRepository.CreateBookAsync(book);
            book.Id = res;

            await _mediator.Publish(new BookCreatedEvent(book), cancellationToken);
            return new AddBookResponse(res);
        }

    }
}
