using Integrify_s_Project.Application.Common.Mappings;
using Integrify_s_Project.Domain.Entities;

namespace Integrify_s_Project.Application.TodoItems.Queries.GetTodoItemsWithPagination;
public class TodoItemBriefDto : IMapFrom<TodoItem>
{
    public int Id { get; set; }

    public int ListId { get; set; }

    public string? Title { get; set; }

    public bool Done { get; set; }
}
