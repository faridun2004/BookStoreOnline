using BookStore.Client.Models;

namespace BookStore.Client.Services
{
    public interface ICartService
    {
        Task<Cart> GetCart();
        Task AddToCart(CartItem item);
        Task RemoveFromCart(int productId);
        Task ClearCart();
        Task UpdateQuantity(int productId, int newQuantity);
    }
}
