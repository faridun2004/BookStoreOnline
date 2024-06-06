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
        private readonly IWebHostEnvironment _environment;
        private readonly ILogger<BooksController> _logger;

        public BooksController(IBookService bookService, IWebHostEnvironment environment, ILogger<BooksController> logger)
        {
            _bookService = bookService;
            _environment = environment ?? throw new ArgumentNullException(nameof(environment));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            var dishes = await _bookService.GetAllAsync();
            return Ok(dishes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var dish = await _bookService.GetByIdAsync(id);
            if (dish == null)
            {
                return NotFound();
            }
            return Ok(dish);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> PostBook([FromForm] BookCreateDto bookDto)
        {
            if (bookDto.Image != null)
            {
                var imageUrl = await SaveImage(bookDto.Image);
                var book = new Book
                {
                    Title = bookDto.Title,
                    CategoryId = bookDto.CategoryId,
                    ImageUrl = imageUrl,
                    Price = bookDto.Price
                };

                await _bookService.AddAsync(book);
                return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
            }
            return BadRequest("Image file is required.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, [FromForm] BookCreateDto bookDto)
        {
            var existingDish = await _bookService.GetByIdAsync(id);
            if (existingDish == null)
            {
                return NotFound();
            }

            if (bookDto.Image != null)
            {
                var imageUrl = await SaveImage(bookDto.Image);
                existingDish.ImageUrl = imageUrl;
            }

            existingDish.Title = bookDto.Title;
            existingDish.CategoryId = bookDto.CategoryId;
            existingDish.Price = bookDto.Price;

            await _bookService.UpdateAsync(existingDish);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            await _bookService.DeleteAsync(id);
            return NoContent();
        }

        private async Task<string> SaveImage(IFormFile imageFile)
        {
            var uploads = Path.Combine(_environment.WebRootPath, "uploads");
            if (!Directory.Exists(uploads))
            {
                Directory.CreateDirectory(uploads);
            }
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
            var filePath = Path.Combine(uploads, fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }

            return $"/uploads/{fileName}";
        }

    }
}
