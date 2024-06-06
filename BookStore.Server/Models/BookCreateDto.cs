namespace BookStore.Server.Models
{
    public class BookCreateDto
    {
        public string? Title { get; set; }
        public decimal Price { get; set; }
        public IFormFile? Image { get; set; }  
        public int CategoryId { get; set; }
        public List<int>? AuthorIds { get; set; }
    }
}
