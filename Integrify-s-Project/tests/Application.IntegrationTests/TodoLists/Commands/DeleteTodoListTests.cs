using FluentAssertions;
using Integrify_s_Project.Application.Common.Exceptions;
using Integrify_s_Project.Application.TodoLists.Commands.CreateTodoList;
using Integrify_s_Project.Application.TodoLists.Commands.DeleteTodoList;
using Integrify_s_Project.Domain.Entities;
using NUnit.Framework;

using static Testing;

namespace Integrify_s_Project.Application.IntegrationTests.TodoLists.Commands;
public class DeleteTodoListTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireValidTodoListId()
    {
        var command = new DeleteTodoListCommand(99);
        await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task ShouldDeleteTodoList()
    {
        var listId = await SendAsync(new CreateTodoListCommand
        {
            Title = "New List"
        });

        await SendAsync(new DeleteTodoListCommand(listId));

        var list = await FindAsync<TodoList>(listId);

        list.Should().BeNull();
    }
}
