using Models;

public interface IMapLocationService
{
    CustomMapPoint GetLatLongFromAddress(string address);
}