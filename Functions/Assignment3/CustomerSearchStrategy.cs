using Assignment3;

public partial class CustomerSearch
{
    public interface CustomerSearchStrategy
    {
        List<Customer> search(List<Customer> customers, string searchTerm);
    }
}
