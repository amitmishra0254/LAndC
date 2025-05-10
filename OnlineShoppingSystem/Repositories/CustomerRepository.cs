public interface CustomerRepository
{
    Customer GetCustomer(string cutomerId);
    void SaveChanges();
}
