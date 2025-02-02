using Assignment3;

namespace CustomerSearch
{
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
            var query = from c in db.Customers
                        where c.Country.Contains(searchTerm)
                        orderby
                        c.CustomerID
                        ascending
                        select
                        c;

            return query.ToList();
        }
    }
}
