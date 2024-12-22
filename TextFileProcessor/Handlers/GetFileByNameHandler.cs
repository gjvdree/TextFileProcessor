using MediatR;
using TextFileProcessor.Web.Queries;

namespace TextFileProcessor.Web.Handlers;

/// <summary>
/// Handler for retrieving a file by name
/// </summary>
internal class GetFileByNameQueryHandler : IRequestHandler<GetFileByNameQuery, Stream>
{
    public Task<Stream> Handle(GetFileByNameQuery request, CancellationToken cancellationToken) => Task.FromResult(File.OpenRead(request.FileName) as Stream);
}
