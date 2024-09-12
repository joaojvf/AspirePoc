using AspirePoc.Core.Abstractions.Repositories;
using AspirePoc.Core.Entities;
using MediatR;
using System.Text.Json;

namespace AspirePoc.Core.UseCases.Management.RebuildBookReadModel
{
    public class RebuildBookReadModelHandler(IBookRepository _bookRepository, IReadModelBookRepository _readModelBookRepository)
        : IRequestHandler<RebuildBookReadModelRequest, RebuildBookReadModelResponse>
    {
        public async Task<RebuildBookReadModelResponse> Handle(RebuildBookReadModelRequest request, CancellationToken cancellationToken)
        {
            List<BookReadModel> readModelBooks;
            if (request.RebuildAll is true)
            {
                var books = await _bookRepository.GetAllToRebuildAsync(cancellationToken);
                readModelBooks = BuildBookReadModel(books);
                await _readModelBookRepository.CreateOrReplaceAllReadModelBooksAsync(readModelBooks, cancellationToken);
                return new RebuildBookReadModelResponse();
            }

            if (request.BookIds?.Any() is true)
            {
                var books = await _bookRepository.GetBooksById(request.BookIds!);
                readModelBooks = BuildBookReadModel(books);
                await _readModelBookRepository.CreateOrReplaceReadModelBooksAsync(readModelBooks, cancellationToken);
            }

            return new RebuildBookReadModelResponse();
        }

        private static List<BookReadModel> BuildBookReadModel(List<Book> books)
        {
            return books.Select(x => new BookReadModel
            {
                Id = x.Id,
                Guid = x.Guid,
                Description = x.Description,
                Title = x.Tittle,
                SerializedObject = JsonSerializer.Serialize(x)
            }).ToList();
        }

    }
}
