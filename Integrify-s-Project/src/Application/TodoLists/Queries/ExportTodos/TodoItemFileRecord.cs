using Integrify_s_Project.Application.Common.Mappings;
using Integrify_s_Project.Domain.Entities;

namespace Integrify_s_Project.Application.TodoLists.Queries.ExportTodos;
public class TodoItemRecord : IMapFrom<TodoItem>
{
    public string? Title { get; set; }

    public bool Done { get; set; }
}
