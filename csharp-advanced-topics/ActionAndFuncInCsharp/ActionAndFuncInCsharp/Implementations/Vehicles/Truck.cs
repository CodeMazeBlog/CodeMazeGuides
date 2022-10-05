using ActionAndFuncInCsharp.Interfaces;

namespace ActionAndFuncInCsharp.Implementations.Vehicles
{
    public class Truck : IVehicle
    {
        public string Park()
        {
            return "The Truck is parked.";
        }
    }
}
