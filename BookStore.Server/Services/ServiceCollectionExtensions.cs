using BookStore.Server.Models;
using BookStore.Server.Repositories.Books;
using BookStore.Server.Repositories.Categories;
using BookStore.Server.Repositories.Orders;
using BookStore.Server.Services;
using BookStore.Server.Services.Authors;
using BookStore.Server.Services.Orders;
using BookStoreOnline.Services.Books;
using BookStoreOnline.Services.Categories;
using FluentAssertions.Common;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace BookStoreOnline.Services
{
    public static class ServiceCollectionExtensions
    {
        public static void AddMyServices(this IServiceCollection service)
        {
            service.AddScoped<IBookRepository, BookRepository>();
            service.AddScoped<IOrderRepository, OrderRepository>();
            service.AddScoped<ICategoryRepository, CategoryRepository>();
            service.AddScoped<IBookService, BookService>();
            service.AddScoped<IAuthorService, AuthorService>();
            service.AddScoped<ICategoryService, CategoryService>();
            service.AddSingleton<ICartService, CartService>();  
            service.AddScoped<IOrderService, OrderService>();
            service.AddScoped<IOrderRepository, OrderRepository>();
        }
    }
}
