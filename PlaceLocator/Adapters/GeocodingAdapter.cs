namespace PlaceLocator.Adapters
{
    public interface GeocodingAdapter
    {
        Task<Tuple<double, double>> GetCoordinatesFromAddressAsync(string address);
    }
}
