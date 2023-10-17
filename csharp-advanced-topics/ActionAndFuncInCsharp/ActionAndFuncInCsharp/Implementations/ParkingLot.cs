using ActionAndFuncInCsharp.Interfaces;

namespace ActionAndFuncInCsharp.Implementations
{
    public class ParkingLot : IParkingLot
    {
        public string Park(IVehicle vehicle)
        {
            return vehicle.Park();
        }
    }
}
