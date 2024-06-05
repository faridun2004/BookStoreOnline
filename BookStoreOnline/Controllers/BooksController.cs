using BookStore.Server.Models;
using BookStoreOnline.Data;
using BookStoreOnline.Models;
using BookStoreOnline.Services.Books;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStoreOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            var books = await _bookService.GetBooksAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(BookCreateDto bookDto)
        {
            var book = new Book
            {
                Title = bookDto.Title,
                Price = bookDto.Price,
                ImageUrl = bookDto.ImageUrl,
                CategoryId = bookDto.CategoryId,
                BookAuthors = bookDto.AuthorIds.Select(aid => new BookAuthor { AuthorId = aid }).ToList()
            };

            var newBook = await _bookService.AddBookAsync(book);
            return CreatedAtAction("GetBook", new { id = newBook.Id }, newBook);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            var updatedBook = await _bookService.UpdateBookAsync(id, book);

            if (updatedBook == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var result = await _bookService.DeleteBookAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }

}
