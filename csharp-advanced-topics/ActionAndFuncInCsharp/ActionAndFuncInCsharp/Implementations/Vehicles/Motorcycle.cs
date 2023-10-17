using ActionAndFuncInCsharp.Interfaces;

namespace ActionAndFuncInCsharp.Implementations.Vehicles
{
    public class Motorcycle : IVehicle
    {
        public string Park()
        {
            return "The Motorcycle is parked.";
        }
    }
}
