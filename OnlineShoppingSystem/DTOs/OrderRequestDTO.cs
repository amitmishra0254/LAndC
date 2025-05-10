namespace OnlineShoppingSystem.DTOs
{
    public class OrderRequestDTO
    {
        public List<OrderItem> items { get; set; }
        public int customerId { get; set; }
    }
}
