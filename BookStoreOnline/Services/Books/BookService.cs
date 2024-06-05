using BookStoreOnline.Data;
using BookStoreOnline.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreOnline.Services.Books
{
    public class BookService : IBookService
    {
        private readonly BookContext _context;

        public BookService(BookContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await _context.Books.Include(b => b.Category)
                                       .Include(b => b.BookAuthors)
                                       .ThenInclude(ba => ba.Author)
                                       .ToListAsync();
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _context.Books.Include(b => b.Category)
                                       .Include(b => b.BookAuthors)
                                       .ThenInclude(ba => ba.Author)
                                       .FirstOrDefaultAsync(b => b.Id == id);
        }
        public async Task<Book> AddBookAsync(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }
        public async Task<Book> UpdateBookAsync(int id, Book book)
        {
            if (id != book.Id)
            {
                return null;
            }
            _context.Entry(book).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return book;
        }
        public async Task<bool> DeleteBookAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return false;
            }
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
