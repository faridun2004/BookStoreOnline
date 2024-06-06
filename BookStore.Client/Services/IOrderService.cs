using BookStore.Client.Models;

namespace BookStore.Client.Services
{
    public interface IOrderService
    {
        Task<bool> PlaceOrder(OrderCreateDto orderCreateDto);
    }
}
