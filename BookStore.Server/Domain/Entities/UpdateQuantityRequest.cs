namespace BookStore.Server.Domain.Entities
{
    public class UpdateQuantityRequest
    {
        public int BookId { get; set; }
        public int NewQuantity { get; set; }
    }
}
