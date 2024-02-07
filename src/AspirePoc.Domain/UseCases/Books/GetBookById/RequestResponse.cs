using AspirePoc.Core.Entities;
using MediatR;

namespace AspirePoc.Core.UseCases.Books.GetBookById
{
    public record GetByIdBookRequest(int Id) : IRequest<GetByIdBookResponse>;
    public record GetByIdBookResponse(Book Book);
}
