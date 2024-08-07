using AspirePoc.Core.Abstractions.Repositories;
using AspirePoc.Core.UseCases.Books.Validators;
using FluentValidation;

namespace AspirePoc.Core.UseCases.Books.UpdateBook
{
    internal class UpdateBookValidator : BookBaseValidator<UpdateBookRequest>
    {
        private readonly IBookRepository _bookRepository;
        const string errorField = "Error";

        public UpdateBookValidator(IBookRepository bookRepository, ICategoryRepository categoryRepository) : base(categoryRepository)
        {
            _bookRepository = bookRepository;

            RuleFor(x => x)
                .MustAsync((field, _, context, _) => ValidatedWithSuccess(field, context))
                .WithMessage("Error when validate: {errorField}");
        }

        private async Task<bool> ValidatedWithSuccess(UpdateBookRequest request, ValidationContext<UpdateBookRequest> context)
        {
            var existentBook = await _bookRepository.GetBookAsync(request.Id);

            if (existentBook is null)
            {
                context.MessageFormatter.AppendArgument(errorField, $"The book {request.Id} don't exists");
                return false;
            }

            if (TittleOrAuthorChanged(request, existentBook))
            {
                context.MessageFormatter.AppendArgument(errorField, $"The book {request.Tittle} of {request.AuthorName} already exists.");
                return false;
            }

            return true;

            static bool TittleOrAuthorChanged(UpdateBookRequest request, Entities.Book existentBook)
            {
                return existentBook.Tittle != request.Tittle
                                    || existentBook.AuthorName != request.AuthorName;
            }
        }

    }
}
