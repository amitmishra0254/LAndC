using OnlineShoppingSystem.Exceptions;
using Microsoft.Extensions.Logging;

public class ProductRepositoryImp : ProductRepository
{
    private Dictionary<string, Product> products = new Dictionary<string, Product>();
    private readonly ILogger<ProductRepositoryImp> logger;

    public ProductRepositoryImp(ILogger<ProductRepositoryImp> logger)
    {
        this.logger = logger;
    }

    public Product GetProduct(string productId)
    {
        if (!products.TryGetValue(productId, out var product))
        {
            Console.WriteLine("Product not found");
            throw new ProductNotFoundException("Order not found");
        }
        return product;
    }

    public int CreateProduct(Order order)
    {
        this.logger.LogInformation("Creating Order.");
        return 1; // Returning order id.
    }

    public void SaveChanges()
    {
        Console.WriteLine("Saving...");
    }
}
