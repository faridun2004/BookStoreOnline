namespace BookStore.Server.Models
{
    public class CartItem
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int CartItemId { get; internal set; }
    }
}
