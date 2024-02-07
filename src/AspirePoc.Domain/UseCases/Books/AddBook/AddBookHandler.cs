using AspirePoc.Core.Abstractions.Repositories;
using AspirePoc.Core.Entities;
using AspirePoc.Core.Exceptions;
using MediatR;

namespace AspirePoc.Core.UseCases.Books.AddBook
{
    public class GetBookByIdHandler(IBookRepository _bookRepository, ICategoryRepository _categoryRepository) : IRequestHandler<AddBookRequest, AddBookResponse>
    {
        public async Task<AddBookResponse> Handle(AddBookRequest request, CancellationToken cancellationToken)
        {
            if (await _bookRepository.HaveABookWithSameNameAndAuthorAsync(request.Tittle, request.AuthorName))
            {
                throw new BookAlreadyAddedException(request.Tittle, request.AuthorName);
            }

            var category = await _categoryRepository.GetCategoryAsync(request.CategoryId) ?? throw new CategoryNotFoundException(request.CategoryId);

            var book = new Book
            {
                Tittle = request.Tittle,
                AuthorName = request.AuthorName,
                Description = request.Description,
                ReleaseDate = request.ReleaseDate,
                CategoryId = category.Id,
            };

            return new(await _bookRepository.CreateBookAsync(book));
        }
    }
}
