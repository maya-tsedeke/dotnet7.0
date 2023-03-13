﻿using Integrify_s_Project.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Integrify_s_Project.Application.TodoItems.EventHandlers;
public class TodoItemCompletedEventHandler : INotificationHandler<TodoItemCompletedEvent>
{
    private readonly ILogger<TodoItemCompletedEventHandler> _logger;

    public TodoItemCompletedEventHandler(ILogger<TodoItemCompletedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(TodoItemCompletedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Integrify_s_Project Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}