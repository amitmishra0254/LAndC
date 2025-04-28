using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PlaceLocator.Constants
{
    public static class ApplicationConstants
    {
        public static string BaseAddress = "https://geocode.maps.co/search?q={0}&api_key={1}";
        public static string GeocodingAPIKey = "GeocodingAPIKey";
        public static string ResultNotFoundMessage = "No results found with address: {0}.";
        public static string ApiCallFaildMessage = "API call failed. Status Code: {response.StatusCode}";
    }
}
