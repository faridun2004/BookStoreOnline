namespace BookStore.Server.Models
{
    public class UpdateQuantityRequest
    {
        public int BookId { get; set; }
        public int NewQuantity { get; set; }
    }
}
