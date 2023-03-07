using Applications.Contracts.Persistence;
using Domain.Entities.Order;
using Infrastructure.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

internal class OrderRepository : BaseAsyncRepository<Order>, IOrderRepository
{
    public OrderRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task AddOrderAsync(Order order)
    {
        await base.AddAsync(order);
    }

    public async Task<List<Order>> GetAllUserOrdersAsync(int userId)
    {
        return await base.TableNoTracking.Where(c => c.UserId == userId).ToListAsync();
    }

    public async Task<List<Order>> GetAllOrdersWithRelatedUserAsync()
    {
        var orders = await base.TableNoTracking.Include(c => c.User).ToListAsync();

        return orders;
    }
}