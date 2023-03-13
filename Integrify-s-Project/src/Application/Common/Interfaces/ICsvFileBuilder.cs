using Integrify_s_Project.Application.TodoLists.Queries.ExportTodos;

namespace Integrify_s_Project.Application.Common.Interfaces;
public interface ICsvFileBuilder
{
    byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
}
