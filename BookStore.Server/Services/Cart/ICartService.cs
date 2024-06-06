using BookStore.Server.Models;

namespace BookStore.Server.Services
{
    public interface ICartService
    {
        Cart GetCart();
        void AddToCart(CartItem item);
        void RemoveFromCart(int productId);
        void ClearCart();
        void UpdateQuantity(int productId, int newQuantity);
    }
}
