using Domain.Entities.Order;

namespace Applications.Contracts.Persistence;

public interface IOrderRepository
{
    Task AddOrderAsync(Order order);
    Task<List<Order>> GetAllUserOrdersAsync(int userId);
    Task<List<Order>> GetAllOrdersWithRelatedUserAsync();
}