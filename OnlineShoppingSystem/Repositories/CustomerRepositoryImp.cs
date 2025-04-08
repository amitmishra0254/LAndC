using OnlineShoppingSystem.Exceptions;

public class CustomerRepositoryImp : CustomerRepository
{
    private Dictionary<string, Customer> customers = new Dictionary<string, Customer>();

    public Customer GetCustomer(string cutomerId)
    {
        if (!customers.TryGetValue(cutomerId, out var customer))
        {
            Console.WriteLine("Customer not found");
            throw new NotFoundException("Order not found");
        }
        return customer;
    }

    public void SaveChanges()
    {
        Console.WriteLine("Saving...");
    }
}
