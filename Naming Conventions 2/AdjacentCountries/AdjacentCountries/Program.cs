using Newtonsoft.Json;

namespace AdjacentCountries
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Please enter a country code to get Adjacent Countries: ");
                string countryCode = Console.ReadLine().Trim().ToUpper();
                var countries = deserializeCountries();
                if (!isValidCountry(countryCode))
                {
                    Console.WriteLine("Invalid country code. Please give a country code from the belows.");
                    Console.WriteLine(string.Join(", ", countries.Keys.ToList()).ToString());
                    return;
                }
                if (countries[countryCode].Count > 0)
                {
                    Console.WriteLine(string.Join(", ", countries[countryCode]));
                }
                else
                {
                    Console.WriteLine($"No Adjacent Countries are present for {countryCode} Country Code.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong. Please try again later.");
            }
        }

        public static Dictionary<string, List<string>> deserializeCountries()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string countryDirectory = Directory.GetParent(currentDirectory).Parent.Parent.FullName + "//Country.json";
            string json = File.ReadAllText(countryDirectory);
            var countryDictionary = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(json);
            return countryDictionary;
        }

        public static bool isValidCountry(string countryCode)
        {
            var countryDictionary = deserializeCountries();
            return countryDictionary.Keys.Contains(countryCode);
        }
    }
}
