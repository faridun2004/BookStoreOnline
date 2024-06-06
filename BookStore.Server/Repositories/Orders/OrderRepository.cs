using BookStore.Server.Models;
using BookStoreOnline.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Server.Repositories.Orders
{
    public class OrderRepository : IOrderRepository
    {
        private readonly BookContext _context;

        public OrderRepository(BookContext context)
        {
            _context = context;
        }

        public async Task<Order> CreateOrderAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _context.Orders.ToListAsync();
        }
    }
}
