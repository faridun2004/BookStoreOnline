using BookStoreOnline.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreOnline.Data
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BookAuthor>().HasKey(ba => new { ba.BookId, ba.AuthorId });

            // Seed data
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Fiction" },
                new Category { Id = 2, Name = "Non-Fiction" }
            );

            modelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, Name = "Author One" },
                new Author { Id = 2, Name = "Author Two" }
            );

            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "Book One", Price = 9.99m, ImageUrl = "image1.jpg", CategoryId = 1 },
                new Book { Id = 2, Title = "Book Two", Price = 19.99m, ImageUrl = "image2.jpg", CategoryId = 2 }
            );

            modelBuilder.Entity<BookAuthor>().HasData(
                new BookAuthor { BookId = 1, AuthorId = 1 },
                new BookAuthor { BookId = 1, AuthorId = 2 },
                new BookAuthor { BookId = 2, AuthorId = 2 }
            );
        }
    }
}
