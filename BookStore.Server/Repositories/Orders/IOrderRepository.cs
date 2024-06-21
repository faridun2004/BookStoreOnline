using BookStore.Server.Domain.Entities;

namespace BookStore.Server.Repositories.Orders
{
    public interface IOrderRepository
    {
        Task<Order> CreateOrderAsync(Order order);
        Task<IEnumerable<Order>> GetAllOrdersAsync();
    }
}
