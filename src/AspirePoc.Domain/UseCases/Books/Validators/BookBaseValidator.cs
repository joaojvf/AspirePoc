using AspirePoc.Core.Abstractions.Repositories;
using FluentValidation;

namespace AspirePoc.Core.UseCases.Books.Validators
{
    internal class BookBaseValidator<TRequest> : AbstractValidator<TRequest> where TRequest : BookBaseRequest
    {
        private readonly ICategoryRepository _categoryRepository;
        public BookBaseValidator(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;

            RuleFor(x => x.CategoryId)
                .MustAsync((field, token) => CategoryExistAsync(field))
                .WithMessage($"No category with id was found.");
        }

        private async Task<bool> CategoryExistAsync(int id) =>
            await _categoryRepository.GetCategoryAsync(id) is not null;
    }
}
