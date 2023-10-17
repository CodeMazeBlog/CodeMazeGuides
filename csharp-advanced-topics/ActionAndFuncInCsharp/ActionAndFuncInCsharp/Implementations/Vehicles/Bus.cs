using ActionAndFuncInCsharp.Interfaces;

namespace ActionAndFuncInCsharp.Implementations.Vehicles
{
    public class Bus : IVehicle
    {
        public string Park()
        {
            return "The Bus is parked.";
        }
    }
}
