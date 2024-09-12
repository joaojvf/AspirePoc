using MediatR;

namespace AspirePoc.Core.UseCases.Management.RebuildBookReadModel
{
    public record RebuildBookReadModelRequest(bool? RebuildAll, IReadOnlyList<Guid>? BookIds) : IRequest<RebuildBookReadModelResponse>;
    public record RebuildBookReadModelResponse();
}
