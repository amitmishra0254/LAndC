using Assignment3;

namespace CustomerSearch
{
    public interface ExportStrategy
    {
        string Export(List<Customer> customers);
    }
}
