using BookStore.Server.Models;

namespace BookStore.Server.Repositories.Orders
{
    public interface IOrderRepository
    {
        Task<Order> CreateOrderAsync(Order order);
        Task<IEnumerable<Order>> GetAllOrdersAsync();
    }
}
