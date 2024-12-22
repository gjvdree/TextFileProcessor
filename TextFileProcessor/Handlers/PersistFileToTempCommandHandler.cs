using MediatR;
using TextFileProcessor.Web.Commands;

namespace TextFileProcessor.Web.Handlers;

/// <summary>
/// Handler for persisting a file
/// </summary>
internal class PersistFileToTempCommandHandler : IRequestHandler<PersistFileToTempCommand, string>
{
    public async Task<string> Handle(PersistFileToTempCommand request, CancellationToken cancellationToken)
    {
        // Persist the file
        string tempFilePath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
        using (FileStream stream = new(tempFilePath, FileMode.Create))
        {
            await request.FileStream.CopyToAsync(stream);
        }

        return tempFilePath;
    }
}
