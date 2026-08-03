using MediatR;

namespace MediatrParallelPublishing;

public sealed record Notification(string Message) : INotification;