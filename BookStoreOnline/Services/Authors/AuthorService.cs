using BookStoreOnline.Data;
using BookStoreOnline.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreOnline.Services.Authors
{
    public class AuthorService : IAuthorService
    {
        private readonly BookContext _context;

        public AuthorService(BookContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Author>> GetAuthorsAsync()
        {
            return await _context.Authors.Include(a => a.BookAuthors)
                                         .ThenInclude(ba => ba.Book)
                                         .ToListAsync();
        }

        public async Task<Author> GetAuthorByIdAsync(int id)
        {
            return await _context.Authors.Include(a => a.BookAuthors)
                                         .ThenInclude(ba => ba.Book)
                                         .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Author> AddAuthorAsync(Author author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
            return author;
        }

        public async Task<Author> UpdateAuthorAsync(int id, Author author)
        {
            if (id != author.Id)
            {
                return null;
            }

            _context.Entry(author).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return author;
        }

        public async Task<bool> DeleteAuthorAsync(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null)
            {
                return false;
            }

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
