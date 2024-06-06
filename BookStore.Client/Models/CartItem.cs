using System.ComponentModel.DataAnnotations;

namespace BookStore.Client.Models
{
    public class CartItem
    {
        [Key]
        public int BookId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int CartItemId { get; internal set; }
    }
}
