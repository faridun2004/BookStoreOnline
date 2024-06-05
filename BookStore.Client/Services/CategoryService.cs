using BookStore.Client.Models;
using System.Net.Http.Json;

namespace BookStore.Client.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Category>>("api/categories");
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Category>($"api/categories/{id}");
        }

        public async Task<Category> AddCategoryAsync(Category category)
        {
            var response = await _httpClient.PostAsJsonAsync("api/categories", category);
            return await response.Content.ReadFromJsonAsync<Category>();
        }

        public async Task<Category> UpdateCategoryAsync(int id, Category category)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/categories/{id}", category);
            return await response.Content.ReadFromJsonAsync<Category>();
        }

        public async Task DeleteCategoryAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/categories/{id}");
        }
    }
}
