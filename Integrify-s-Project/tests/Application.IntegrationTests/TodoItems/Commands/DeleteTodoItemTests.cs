using FluentAssertions;
using Integrify_s_Project.Application.Common.Exceptions;
using Integrify_s_Project.Application.TodoItems.Commands.CreateTodoItem;
using Integrify_s_Project.Application.TodoItems.Commands.DeleteTodoItem;
using Integrify_s_Project.Application.TodoLists.Commands.CreateTodoList;
using Integrify_s_Project.Domain.Entities;
using NUnit.Framework;

using static Testing;

namespace Integrify_s_Project.Application.IntegrationTests.TodoItems.Commands;
public class DeleteTodoItemTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireValidTodoItemId()
    {
        var command = new DeleteTodoItemCommand(99);

        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task ShouldDeleteTodoItem()
    {
        var listId = await SendAsync(new CreateTodoListCommand
        {
            Title = "New List"
        });

        var itemId = await SendAsync(new CreateTodoItemCommand
        {
            ListId = listId,
            Title = "New Item"
        });

        await SendAsync(new DeleteTodoItemCommand(itemId));

        var item = await FindAsync<TodoItem>(itemId);

        item.Should().BeNull();
    }
}
