public interface ProductRepository
{
    Product GetProduct(string productId);
    int CreateProduct(Order order);
    void SaveChanges();
}
