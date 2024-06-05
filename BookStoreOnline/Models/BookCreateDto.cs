namespace BookStore.Server.Models
{
    public class BookCreateDto
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public ICollection<int> AuthorIds { get; set; }
    }
}
