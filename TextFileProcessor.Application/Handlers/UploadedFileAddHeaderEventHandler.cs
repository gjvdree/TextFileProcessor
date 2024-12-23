using MediatR;
using TextFileProcessor.Application.Services.Interfaces;
using TextFileProcessor.Domain.Events;

namespace TextFileProcessor.Application.Handlers;

/// <summary>
/// Eventhandler to handle the <see cref="FileUploadedEvent"/>
/// This handler will add header information
/// </summary>
/// <param name="fileProcessorService">The fileProcessorService which will add the header information</param>
internal class UploadedFileAddHeaderEventHandler(IFileProcessorService fileProcessorService) : INotificationHandler<FileUploadedEvent>
{
    public async Task Handle(FileUploadedEvent fileUploaded, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        await fileProcessorService.AddHeaderInformation(fileUploaded.FilePath, DateTime.UtcNow);
    }
}
