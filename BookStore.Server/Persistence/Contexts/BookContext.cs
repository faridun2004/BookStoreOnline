using BookStore.Server.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Server.Persistence.Contexts
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public BookContext(DbContextOptions<BookContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Fiction" },
            new Category { Id = 2, Name = "Non-Fiction" },
            new Category { Id = 3, Name = "Science" }
            );
            modelBuilder.Entity<Author>().HasData(
            new Author { Id = 1, Name = "Author One" },
            new Author { Id = 2, Name = "Author Two" }
            );
            modelBuilder.Entity<Book>().HasData(
            new Book { Id = 1, Title = "Book One", Price = 29.99m, ImageUrl = "https://example.com/book1.jpg", CategoryId = 1 },
            new Book { Id = 2, Title = "Book Two", Price = 39.99m, ImageUrl = "https://example.com/book2.jpg", CategoryId = 2 }
            );
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            // Author Configuration
            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.Property(a => a.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            // Book Configuration
            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(b => b.Id);
                entity.Property(b => b.Title)
                    .IsRequired()
                    .HasMaxLength(200);
                entity.Property(b => b.Price)
                    .HasColumnType("decimal(18,2)");
                entity.Property(b => b.ImageUrl)
                    .HasMaxLength(200);

                entity.HasOne(b => b.Category)
                    .WithMany(c => c.Books)
                    .HasForeignKey(b => b.CategoryId);
            });

            // BookAuthor Configuration (many-to-many relationship)
            modelBuilder.Entity<BookAuthor>(entity =>
            {
                entity.HasKey(ba => new { ba.BookId, ba.AuthorId });

                entity.HasOne(ba => ba.Book)
                    .WithMany(b => b.BookAuthors)
                    .HasForeignKey(ba => ba.BookId);

                entity.HasOne(ba => ba.Author)
                    .WithMany(a => a.BookAuthors)
                    .HasForeignKey(ba => ba.AuthorId);
            });
            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(e => e.Price)
                .HasColumnType("decimal(18,2)");
            });
            modelBuilder.Entity<Cart>(entity =>
            {
                entity.HasKey(c => c.Id);
            });
            modelBuilder.Entity<CartItem>().HasKey(c => c.CartItemId);
        }
    }
}
