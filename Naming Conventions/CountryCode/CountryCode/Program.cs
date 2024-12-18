namespace CoountryCode
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter a country code to get Adjacent Countries: ");
            string countryCode = Console.ReadLine().Trim().ToUpper();
            if (!isValidCountry(countryCode))
            {
                Console.WriteLine("Invalid country code. Please give a country code from the belows.");
                Console.WriteLine(string.Join(", ", countryCodes.Keys.ToList()).ToString());
                return;
            }
            Console.WriteLine(string.Join(", ", adjacentCountries[countryCode]));
        }

        public static bool isValidCountry(string countryCode)
        {
            return countryCodes.Keys.Contains(countryCode);
        }

        static Dictionary<string, string> countryCodes = new Dictionary<string, string>
        {
            { "IN", "India" },
            { "US", "United States" },
            { "NZ", "New Zealand" },
            { "CA", "Canada" },
            { "AU", "Australia" },
            { "GB", "United Kingdom" },
            { "FR", "France" },
            { "DE", "Germany" },
            { "JP", "Japan" },
            { "CN", "China" },
            { "BR", "Brazil" },
            { "RU", "Russia" },
            { "ZA", "South Africa" },
            { "IT", "Italy" },
            { "ES", "Spain" }
        };

        static Dictionary<string, List<string>> adjacentCountries = new Dictionary<string, List<string>>
        {
            { "IN", new List<string> { "Pakistan", "China", "Nepal", "Bangladesh" } },
            { "US", new List<string> { "Canada", "Mexico" } },
            { "NZ", new List<string> { "Australia" } },
            { "CA", new List<string> { "United States", "Mexico" } },
            { "AU", new List<string> { "New Zealand", "Indonesia" } },
            { "GB", new List<string> { "France", "Germany" } },
            { "FR", new List<string> { "Germany", "Spain", "Italy" } },
            { "DE", new List<string> { "Poland", "France", "Czech Republic" } },
            { "JP", new List<string> { "China", "South Korea" } },
            { "CN", new List<string> { "India", "Russia", "Mongolia" } },
            { "BR", new List<string> { "Argentina", "Chile", "Colombia" } },
            { "RU", new List<string> { "China", "Kazakhstan", "Ukraine" } },
            { "ZA", new List<string> { "Namibia", "Botswana", "Mozambique" } },
            { "IT", new List<string> { "France", "Switzerland", "Austria" } },
            { "ES", new List<string> { "France", "Portugal" } }
        };
    }
}
