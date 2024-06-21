using BookStore.Server.Domain.Entities;

namespace BookStore.Server.Services.Orders
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(OrderCreateDto orderCreateDto);
        Task<Order> GetOrderByIdAsync(int id);
    }
}
