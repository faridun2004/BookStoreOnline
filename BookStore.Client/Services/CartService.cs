using BookStore.Client.Models;
using System.Net.Http.Json;

namespace BookStore.Client.Services
{
    public class CartService : ICartService
    {
        private readonly HttpClient _httpClient;

        public CartService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Cart> GetCart()
        {
            return await _httpClient.GetFromJsonAsync<Cart>("api/cart");
        }

        public async Task AddToCart(CartItem item)
        {
            await _httpClient.PostAsJsonAsync("api/cart", item);
        }

        public async Task RemoveFromCart(int productId)
        {
            await _httpClient.DeleteAsync($"api/cart/{productId}");
        }

        public async Task ClearCart()
        {
            await _httpClient.DeleteAsync("api/cart");
        }
        public async Task UpdateQuantity(int productId, int newQuantity)
        {
            var updateQuantityRequest = new { ProductId = productId, NewQuantity = newQuantity };
            await _httpClient.PutAsJsonAsync("api/cart/update-quantity", updateQuantityRequest);
        }
    }
}
