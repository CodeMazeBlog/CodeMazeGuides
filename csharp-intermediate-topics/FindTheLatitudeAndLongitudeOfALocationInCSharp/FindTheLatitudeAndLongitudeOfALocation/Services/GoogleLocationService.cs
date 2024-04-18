using GoogleMaps.LocationServices;
using Models;

public class GoogleLocationServiceWrapper : IMapLocationService
{
    private readonly GoogleLocationService _glsContext;

    public GoogleLocationServiceWrapper(string apiKey)
    {
        _glsContext = new GoogleLocationService(apiKey);
    }

    public async Task<CustomMapPoint> GetLatLongFromAddressAsync(string address)
    {
        var location = await Task.Run(() => _glsContext.GetLatLongFromAddress(address)); 

        return new CustomMapPoint() { Latitude = location.Latitude, Longitude = location.Longitude };
    }
}