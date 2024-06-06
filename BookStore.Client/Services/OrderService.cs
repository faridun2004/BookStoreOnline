using BookStore.Client.Models;
using System.Net.Http.Json;

namespace BookStore.Client.Services
{
    public class OrderService: IOrderService
    {
        private readonly HttpClient _httpClient;

        public OrderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> PlaceOrder(OrderCreateDto orderCreateDto)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/orders", orderCreateDto);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
