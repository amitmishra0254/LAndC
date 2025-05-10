namespace OnlineShoppingSystem.Managers
{
    public interface ProductManager
    {
        bool IsProductIsInStock(List<OrderItem> items);
    }
}
