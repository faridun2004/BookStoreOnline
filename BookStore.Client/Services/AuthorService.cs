using BookStore.Client.Models;
using System.Net.Http.Json;

namespace BookStore.Client.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly HttpClient _httpClient;

        public AuthorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Author>> GetAuthorsAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Author>>("api/authors");
        }

        public async Task<Author> GetAuthorByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Author>($"api/authors/{id}");
        }

        public async Task<Author> AddAuthorAsync(Author author)
        {
            var response = await _httpClient.PostAsJsonAsync("api/authors", author);
            return await response.Content.ReadFromJsonAsync<Author>();
        }

        public async Task<Author> UpdateAuthorAsync(int id, Author author)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/authors/{id}", author);
            return await response.Content.ReadFromJsonAsync<Author>();
        }

        public async Task DeleteAuthorAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/authors/{id}");
        }
    }
}
