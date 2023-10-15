using ActionAndFuncInCsharp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
