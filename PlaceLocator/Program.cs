using Microsoft.Extensions.Configuration;
using PlaceLocator.Adapters;
using PlaceLocator.Exceptions;
using System.Net;

namespace PlaceLocator
{
    public class PlaceLocator
    {
        public static async Task Main(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            HttpClient httpClient = new HttpClient();
            GeocodingAdapter geocodingAdapter = new GeocodingAdapterImp(httpClient, configuration);

            try
            {
                Tuple<double, double> coordinates = await geocodingAdapter.GetCoordinatesFromAddressAsync(GetAddressFromUser());
                Console.WriteLine($"Latitude: {coordinates.Item1}, Longitude: {coordinates.Item2}");
            }
            catch (GeocodingException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static string GetAddressFromUser()
        {
            Console.Write("Enter the address you want to locate: ");
            string address = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(address))
            {
                Console.WriteLine("Address cannot be empty. Please enter a valid address.");
                Console.Write("Enter the address you want to locate: ");
                address = Console.ReadLine();
            }

            return address;
        }

    }
}