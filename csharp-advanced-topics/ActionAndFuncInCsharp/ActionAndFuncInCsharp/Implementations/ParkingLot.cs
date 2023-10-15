using ActionAndFuncInCsharp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
