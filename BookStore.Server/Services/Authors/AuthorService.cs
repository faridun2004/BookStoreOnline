using BookStore.Server.Domain.Entities;
using BookStore.Server.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Server.Services.Authors
{
    public class AuthorService: IAuthorService
    {
        private readonly BookContext _context;

        public AuthorService(BookContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Author>> GetAllAuthorsAsync()
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

        public async Task AddAuthorAsync(Author author)
        {
            await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAuthorAsync(Author author)
        {
            _context.Authors.Update(author);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAuthorAsync(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author != null)
            {
                _context.Authors.Remove(author);
                await _context.SaveChangesAsync();
            }
        }
    }
}
