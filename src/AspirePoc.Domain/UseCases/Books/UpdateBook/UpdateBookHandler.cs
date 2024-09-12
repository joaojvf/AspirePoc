using AspirePoc.Core.Abstractions.Repositories;
using AspirePoc.Core.Entities;
using AspirePoc.Core.Exceptions;
using AspirePoc.Core.Messages;
using FluentValidation;
using MediatR;

namespace AspirePoc.Core.UseCases.Books.UpdateBook
{
    public class UpdateBookHandler(
        IBookRepository _bookRepository,
        IValidator<UpdateBookRequest> _validator) : IRequestHandler<UpdateBookRequest, UpdateBookResponse>
    {
        public async Task<UpdateBookResponse> Handle(UpdateBookRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new FluentValidationException(validationResult);
            }

            var existentBook = await _bookRepository.GetBookAsync(request.Id);
            UpdateBookFields(request, existentBook!);
            
            existentBook!.AddMessage(new BookUpdatedEvent(existentBook));
            await _bookRepository.SaveChangesAsync();

            return new();
        }

        private static void UpdateBookFields(UpdateBookRequest request, Book existentBook)
        {
            existentBook.CategoryId = request.CategoryId;
            existentBook.ReleaseDate = request.ReleaseDate;
            existentBook.Description = request.Description;
        }
    }
}
