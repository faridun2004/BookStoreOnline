namespace BookStore.Server.Models
{
    public class OrderCreateDto
    {
        public List<OrderItemCreateDto> OrderItems { get; set; } = new List<OrderItemCreateDto>();
        public string? CustomerName { get; set; }
        public string? CustomerEmail { get; set; }
        public string? CustomerAddress { get; set; }
    }
}
