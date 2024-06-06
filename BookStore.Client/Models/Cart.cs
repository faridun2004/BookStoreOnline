using System.ComponentModel.DataAnnotations;

namespace BookStore.Client.Models
{
    public class Cart
    {
        [Key] // Указываем, что это первичный ключ
        public int CartId { get; set; }
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        public decimal TotalPrice
        {
            get
            {
                return Items.Sum(item => item.Price * item.Quantity);
            }
        }
    }
}
