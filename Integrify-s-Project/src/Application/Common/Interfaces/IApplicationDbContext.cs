using Integrify_s_Project.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Integrify_s_Project.Application.Common.Interfaces;
public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
