using Integrify_s_Project.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Integrify_s_Project.Application.TodoItems.EventHandlers;
public class TodoItemCreatedEventHandler : INotificationHandler<TodoItemCreatedEvent>
{
    private readonly ILogger<TodoItemCreatedEventHandler> _logger;

    public TodoItemCreatedEventHandler(ILogger<TodoItemCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(TodoItemCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Integrify_s_Project Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
