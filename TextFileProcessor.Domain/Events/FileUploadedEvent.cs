using MediatR;

namespace TextFileProcessor.Domain.Events;

public record FileUploadedEvent(string FilePath) : INotification;
