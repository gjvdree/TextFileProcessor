using MediatR;
using TextFileProcessor.Web.Events;
using TextFileProcessor.Web.Services.Interfaces;

namespace TextFileProcessor.Web.Handlers;

/// <summary>
/// Eventhandler to handle the <see cref="FileUploadedEvent"/>
/// This handler will add random characters to the file
/// </summary>
/// <param name="fileProcessorService">The fileProcessorService which will add the random characters</param>
internal class UploadedFileAddCharactersEventHandler(IFileProcessorService fileProcessorService) : INotificationHandler<FileUploadedEvent>
{
    public async Task Handle(FileUploadedEvent fileUploaded, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        await fileProcessorService.AddRandomCharacters(fileUploaded.FilePath);
    }
}
