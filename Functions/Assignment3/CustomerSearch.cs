using Assignment3;
using System.Text;

namespace CustomerSearch
{
    public class CSVExport : ExportStrategy
    {
        public string Export(List<Customer> customers)
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var customer in customers)
            {
                stringBuilder.AppendFormat("{0},{1}, {2}, {3}", customer.CustomerID, customer.CompanyName, customer.ContactName, customer.Country);
                stringBuilder.AppendLine();
            }
            return stringBuilder.ToString();
        }
    }
}
