using AspirePoc.Core.Abstractions.Repositories;
using AspirePoc.Core.Entities;
using AspirePoc.Core.Exceptions;
using MediatR;

namespace AspirePoc.Core.UseCases.Books.UpdateBook
{
    public class UpdateBookHandler(
        IBookRepository _bookRepository,
        ICategoryRepository _categoryRepository) : IRequestHandler<UpdateBookRequest, UpdateBookResponse>
    {
        public async Task<UpdateBookResponse> Handle(UpdateBookRequest request, CancellationToken cancellationToken)
        {
            var existentBook = await _bookRepository.GetBookAsync(request.Id);

            ArgumentNullException.ThrowIfNull(existentBook);

            if (existentBook.Tittle != request.Tittle
                && existentBook.AuthorName != request.AuthorName)
            {
                throw new BookInvalidUpdateException(id: request.Id);
            }

            var category = await _categoryRepository
                .GetCategoryAsync(request.CategoryId) ??
                throw new CategoryNotFoundException(request.CategoryId);

            UpdateBookFields(request, existentBook, category);

            await _bookRepository.SaveChangesAsync();

            return new();
        }

        private static void UpdateBookFields(UpdateBookRequest request, Book existentBook, Category category)
        {
            existentBook.Category = category;
            existentBook.CategoryId = request.CategoryId;
            existentBook.ReleaseDate = request.ReleaseDate;
            existentBook.Description = request.Description;
        }
    }
}
