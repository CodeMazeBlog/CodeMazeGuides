using ActionAndFuncInCsharp.Implementations;
using ActionAndFuncInCsharp.Implementations.Vehicles;
using ActionAndFuncInCsharp.Interfaces;

var parkingManager = new ParkingManager();
var progressManager = new ProgressManager();
var parkingLot = new ParkingLot();
var vehicles = new List<IVehicle>() { new Ambulance(), new Car(), new Truck(), new Motorcycle(), new Bus() };

parkingManager.ParkAllVehicles(parkingLot, vehicles, 
    progressManager.GetProgressBarDrawing, progressManager.UpdateProgress);