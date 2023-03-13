using Integrify_s_Project.Application.Common.Mappings;
using Integrify_s_Project.Domain.Entities;

namespace Integrify_s_Project.Application.Common.Models;
// Note: This is currently just used to demonstrate applying multiple IMapFrom attributes.
public class LookupDto : IMapFrom<TodoList>, IMapFrom<TodoItem>
{
    public int Id { get; set; }

    public string? Title { get; set; }
}
