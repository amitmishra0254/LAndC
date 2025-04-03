using OnlineShoppingSystem.Exceptions;
using Microsoft.Extensions.Logging;

public class OrderRepositoryImp : OrderRepository
{
    private Dictionary<string, Order> orderDatabase = new Dictionary<string, Order>();
    private readonly ILogger<OrderRepositoryImp> logger;

    public OrderRepositoryImp(ILogger<OrderRepositoryImp> logger)
    {
        this.logger = logger;
    }

    public Order GetOrder(string orderId)
    {
        if (!orderDatabase.TryGetValue(orderId, out var order))
        {
            Console.WriteLine("Order not found");
            throw new OrderNotFoundException("Order not found");
        }
        return order;
    }

    public int CreateOrder(Order order)
    {
        this.logger.LogInformation("Creating Order.");
        this.logger.LogInformation($"Order placed.");
        return 1; // Returning order id.
    }

    public void SaveChanges()
    {
        Console.WriteLine("Saving...");
    }
}
