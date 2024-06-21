using BookStore.Server.Domain.Entities;
using BookStore.Server.Models;
using BookStore.Server.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Server.Services.Orders
{
    public class OrderService : IOrderService
    {
        private readonly BookContext _context;

        public OrderService(BookContext context)
        {
            _context = context;
        }

        public async Task<Order> CreateOrderAsync(OrderCreateDto orderCreateDto)
        {
            var order = new Order
            {
                CustomerName = orderCreateDto.CustomerName,
                CustomerEmail = orderCreateDto.CustomerEmail,
                CustomerAddress = orderCreateDto.CustomerAddress
            };

            foreach (var item in orderCreateDto.OrderItems)
            {
                var book = await _context.Books.FindAsync(item.BookId);
                if (book != null)
                {
                    var orderItem = new OrderItem
                    {
                        BookId = book.Id,
                        Name = book.Title,
                        Quantity = item.Quantity,
                        Price = book.Price
                    };
                    order.OrderItems.Add(orderItem);
                }
            }

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            var order = await _context.Orders
                .Include(o => o.OrderItems)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null)
            {
                return null;
            }

            return order;
        }
    }
}
