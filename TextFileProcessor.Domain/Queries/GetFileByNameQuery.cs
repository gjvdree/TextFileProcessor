using MediatR;

namespace TextFileProcessor.Domain.Queries;

public record GetFileByNameQuery(string FileName) : IRequest<Stream>;

