using MediatR;

namespace TextFileProcessor.Web.Commands;

/// <summary>
/// Command to save a filestream
/// </summary>
/// <param name="FileStream">Stream to save</param>
internal record PersistFileToTempCommand(string FileName, Stream FileStream) : IRequest<string>;

