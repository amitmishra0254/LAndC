using CustomerSearch;

public class SearchByCompanyName : CustomerSearchStrategy
{
    private readonly ApplicationDbContext db;
    public SearchByCompanyName(ApplicationDbContext db)
    {
        this.db = db;
    }
    // Search customer by companyname
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

