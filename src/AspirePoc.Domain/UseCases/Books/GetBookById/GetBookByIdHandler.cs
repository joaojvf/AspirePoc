using AspirePoc.Core.Abstractions.Repositories;
using AspirePoc.Core.Exceptions;
using MediatR;

namespace AspirePoc.Core.UseCases.Books.GetBookById
{
    public class GetBooksByIdHandler(IReadModelBookRepository _bookRepository) : IRequestHandler<GetByIdBookRequest, GetByIdBookResponse>
    {
        public async Task<GetByIdBookResponse> Handle(GetByIdBookRequest request, CancellationToken cancellationToken)
        {
            var res = await _bookRepository.GetReadModelBookAsync(request.Id);

            if (res is null)
            {
                throw new BookNotFoundException(request.Id);
            }

            return new(res);
        }
    }
}
