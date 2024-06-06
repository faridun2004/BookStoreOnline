namespace BookStore.Server.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
