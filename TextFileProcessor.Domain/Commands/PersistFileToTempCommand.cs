using MediatR;

namespace TextFileProcessor.Domain.Commands;

/// <summary>
/// Command to save a filestream
/// </summary>
/// <param name="FileStream">Stream to save</param>
public record PersistFileToTempCommand(string FileName, Stream FileStream) : IRequest<string>;

