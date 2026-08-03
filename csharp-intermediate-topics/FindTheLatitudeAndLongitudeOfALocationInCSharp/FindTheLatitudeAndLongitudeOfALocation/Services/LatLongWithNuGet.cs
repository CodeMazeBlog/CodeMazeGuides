namespace Services; 

public class LatLongWithNuGet
{
    private readonly IMapLocationService _locationService;

    public LatLongWithNuGet(IMapLocationService locationService)
    {
        _locationService = locationService;
    }

    public async Task<string> GetLatLongWithNuGet(string address)
    {
        try
        {
            var latlong = await _locationService.GetLatLongFromAddressAsync(address);
            
            return $"Address ({address}) is at {latlong.Latitude}, {latlong.Longitude}";
        }
        catch (Exception ex)
        {
            return $"Error retrieving coordinates: {ex.Message}";
        }
    }
}
