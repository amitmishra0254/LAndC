using CustomerSearch;

public class SearchByContact : CustomerSearchStrategy
{
    private readonly ApplicationDbContext db;
    public SearchByContact(ApplicationDbContext db)
    {
        this.db = db;
    }
    // Search customer by contact person
    public List<Customer> search(List<Customer> customers, string searchTerm)
    {
        var query = from c in db.customers
                    where c.Country.Contains(searchTerm)
                    orderby
                    c.CustomerID
                    ascending
                    select
                    c;

        return query.ToList();
    }
}
