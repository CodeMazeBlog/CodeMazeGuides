using ActionAndFuncInCsharp.Interfaces;

namespace ActionAndFuncInCsharp.Implementations
{
    public class ParkingManager
    {
        public void ParkAllVehicles(IParkingLot parkingLot, IList<IVehicle> vehicles, Func<double, string> getProgressBarDrawing, Action<IProgress> updateProgress)
        {
            var progressValue = 0.0;
            var increment = 1.0 / vehicles.Count;
            foreach (var vehicle in vehicles)
            {
                var isParkedMessage = parkingLot.Park(vehicle);
                progressValue += increment;
                var barDrawing = getProgressBarDrawing(progressValue);
                updateProgress(new Progress(isParkedMessage, progressValue, barDrawing));
            }
        }
    }
}
