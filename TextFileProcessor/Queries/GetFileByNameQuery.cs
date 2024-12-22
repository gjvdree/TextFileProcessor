using MediatR;

namespace TextFileProcessor.Web.Queries;

internal record GetFileByNameQuery(string FileName) : IRequest<Stream>;

