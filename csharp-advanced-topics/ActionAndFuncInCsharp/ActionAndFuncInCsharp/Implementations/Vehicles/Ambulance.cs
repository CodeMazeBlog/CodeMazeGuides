using ActionAndFuncInCsharp.Interfaces;

namespace ActionAndFuncInCsharp.Implementations.Vehicles
{
    public class Ambulance : IVehicle
    {
        public string Park()
        {
            return "The Ambulance is parked.";
        }
    }
}
