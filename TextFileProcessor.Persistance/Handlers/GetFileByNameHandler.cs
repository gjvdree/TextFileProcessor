using MediatR;
using TextFileProcessor.Domain.Queries;

namespace TextFileProcessor.Persistance.Handlers;

/// <summary>
/// Handler for retrieving a file by name
/// </summary>
internal class GetFileByNameQueryHandler : IRequestHandler<GetFileByNameQuery, Stream>
{
    public Task<Stream> Handle(GetFileByNameQuery request, CancellationToken cancellationToken) => Task.FromResult(File.OpenRead(request.FileName) as Stream);
}
