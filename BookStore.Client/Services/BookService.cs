using BookStore.Client.Models;
using System.Net.Http.Json;

namespace BookStore.Client.Services
{
    public class BookService : IBookService
    {
        private readonly HttpClient _httpClient;

        public BookService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Book>> GetAllProducts()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Book>>("api/books");
        }

        public async Task<Book> GetProductById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Book>($"api/books/{id}");
        }

        public async Task AddProduct(Book book, MultipartFormDataContent content)
        {
            var response = await _httpClient.PostAsJsonAsync("api/books", book);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateProduct(Book book, MultipartFormDataContent content)
        {
            var response = await _httpClient.PutAsync($"api/books/{book.Id}", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteProduct(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/books/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
