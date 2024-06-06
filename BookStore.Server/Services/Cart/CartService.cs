using BookStore.Server.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace BookStore.Server.Models
{
    public class CartService: ICartService
    {
        private Cart _cart = new Cart();

        public Cart GetCart()
        {
            return _cart;
        }

        public void AddToCart(CartItem item)
        {
            var existingItem = _cart.Items.FirstOrDefault(i => i.BookId == item.BookId);
            if (existingItem != null)
            {
                existingItem.Quantity += item.Quantity;
            }
            else
            {
                _cart.Items.Add(item);
            }
        }

        public void RemoveFromCart(int productId)
        {
            var item = _cart.Items.FirstOrDefault(i => i.BookId == productId);
            if (item != null)
            {
                _cart.Items.Remove(item);
            }
        }

        public void ClearCart()
        {
            _cart.Items.Clear();
        }
        public void UpdateQuantity(int productId, int newQuantity)
        {
            var item = _cart.Items.FirstOrDefault(i => i.BookId == productId);
            if (item != null)
            {
                if (newQuantity > 0)
                {
                    item.Quantity = newQuantity;
                }
                else if (newQuantity < 0)
                {
                    _cart.Items.Remove(item);
                }
            }
        }
    }
}
