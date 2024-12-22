using MediatR;

namespace TextFileProcessor.Web.Events;

internal record FileUploadedEvent(string FilePath) : INotification;
