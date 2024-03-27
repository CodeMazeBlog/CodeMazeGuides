using GoogleMaps.LocationServices;
using Models;
using Services;

public class GoogleLocationServiceWrapper : IMapLocationService
{
    private readonly GoogleLocationService _glsContext;

    public GoogleLocationServiceWrapper(string apiKey)
    {
        _glsContext = new GoogleLocationService(apiKey);
    }

    public CustomMapPoint GetLatLongFromAddress(string address)
    {
        var location = _glsContext.GetLatLongFromAddress(address);

        return new CustomMapPoint() { Latitude = location.Latitude, Longitude = location.Longitude };
    }
}