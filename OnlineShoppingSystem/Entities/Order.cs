public class Order
{
    public string Id { get; set; }
    public string CustomerId { get; set; }
    public List<OrderItem> Items { get; set; }
    public OrderStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public double TotalAmount { get; set; }
    public double DiscountApplied { get; set; }
    public double FinalAmount { get; set; }
}
