using Assignment3;

namespace CustomerSearch
{
    public interface CustomerSearchStrategy
    {
        List<Customer> search(List<Customer> customers, string searchTerm);
    }
}
