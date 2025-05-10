public interface OrderRepository
{
    public Order GetOrder(string orderId);
    int CreateOrder(Order order);
    void SaveChanges();
}
