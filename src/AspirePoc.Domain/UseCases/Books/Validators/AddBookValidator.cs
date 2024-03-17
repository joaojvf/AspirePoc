using AspirePoc.Core.Abstractions.Repositories;
using AspirePoc.Core.UseCases.Books.AddBook;
using FluentValidation;

namespace AspirePoc.Core.UseCases.Books.Validators
{
    internal class AddBookValidator : BookBaseValidator<AddBookRequest>
    {
        private readonly IBookRepository _bookRepository;

        public AddBookValidator(IBookRepository bookRepository, ICategoryRepository categoryRepository) : base(categoryRepository)
        {
            _bookRepository = bookRepository;

            RuleFor(x => x)
                .MustAsync((field, _) => BookIsUniqueAsync(field))
                .WithMessage($"A book with the same Tittle and Author already exists.");
        }

        private async Task<bool> BookIsUniqueAsync(AddBookRequest request) => await _bookRepository.HaveABookWithSameNameAndAuthorAsync(request.Tittle, request.AuthorName);
    }
}
