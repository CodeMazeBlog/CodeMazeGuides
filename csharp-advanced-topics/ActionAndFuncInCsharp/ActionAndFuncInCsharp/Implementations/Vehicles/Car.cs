using ActionAndFuncInCsharp.Interfaces;

namespace ActionAndFuncInCsharp.Implementations.Vehicles
{
    public class Car : IVehicle
    {
        public string Park()
        {
            return "The Car is parked.";
        }
    }
}
