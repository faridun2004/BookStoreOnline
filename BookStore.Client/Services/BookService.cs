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

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Book>>("api/books");
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Book>($"api/books/{id}");
        }

        public async Task<Book> AddBookAsync(Book book)
        {
            var response = await _httpClient.PostAsJsonAsync("api/books", book);
            return await response.Content.ReadFromJsonAsync<Book>();
        }

        public async Task<Book> UpdateBookAsync(int id, Book book)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/books/{id}", book);
            return await response.Content.ReadFromJsonAsync<Book>();
        }

        public async Task DeleteBookAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/books/{id}");
        }
    }
}
