using BookStoreOnline.Services.Authors;
using BookStoreOnline.Services.Books;
using BookStoreOnline.Services.Categories;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace BookStoreOnline.Services
{
    public static class ServiceCollectionExtensions
    {
        public static void AddMyServices(this IServiceCollection service)
        {
            service.AddScoped<IBookService, BookService>();
            service.AddScoped<IAuthorService, AuthorService>();
            service.AddScoped<ICategoryService, CategoryService>();        
        }
    }
}
