using Microsoft.Extensions.Configuration;
using PlaceLocator.Constants;
using PlaceLocator.Exceptions;
using PlaceLocator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PlaceLocator.Adapters
{
    public class GeocodingAdapterImp : GeocodingAdapter
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration configuration;
        public GeocodingAdapterImp(HttpClient httpClient, IConfiguration configuration)
        {
            this.httpClient = httpClient;
            this.configuration = configuration;
        }

        public async Task<Tuple<double, double>> GetCoordinatesFromAddressAsync(string address)
        {
            string returnMessage = "";
            string encodedAddress = Uri.EscapeDataString(address);
            string apiUrl = string.Format(ApplicationConstants.BaseAddress, encodedAddress, configuration[ApplicationConstants.GeocodingAPIKey]);
            HttpResponseMessage response = await httpClient.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                List<Place> places = JsonSerializer.Deserialize<List<Place>>(responseString);
                Place firstResult = places.FirstOrDefault();
                if (firstResult != null)
                {
                    return new Tuple<double, double>(Convert.ToDouble(firstResult.lat), Convert.ToDouble(firstResult.lon));
                }
                else
                {
                    returnMessage = string.Format(ApplicationConstants.ResultNotFoundMessage, address);
                }
            }
            else
            {
                returnMessage = string.Format(ApplicationConstants.ApiCallFaildMessage, response.StatusCode.ToString());
            }
            throw new GeocodingException(returnMessage);
        }
    }
}
