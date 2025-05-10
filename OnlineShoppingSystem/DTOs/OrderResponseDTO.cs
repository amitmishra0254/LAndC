public class OrderResponseDTO
{
    public List<OrderItem> Items { get; set; }
    public object Status { get; set; }
    public double TotalAmount { get; set; }
    public double DiscountApplied { get; set; }
    public double FinalAmount { get; set; }
}
