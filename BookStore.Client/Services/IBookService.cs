using BookStore.Client.Models;

namespace BookStore.Client.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllProducts();
        Task<Book> GetProductById(int id);
        Task AddProduct(Book book, MultipartFormDataContent content);
        Task UpdateProduct(Book book, MultipartFormDataContent content);
        Task DeleteProduct(int id);
    }
}
