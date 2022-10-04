
var parkingManager = new ParkingManager();
var progressManager = new ProgressManager();
var parkingLot = new ParkingLot();
var vehicles = new List<IVehicle>() { new Ambulance(), new Car(), new Truck(), new Motorcycle(), new Bus() };
parkingManager.ParkAllVehicles(parkingLot, vehicles, progressManager.GetProgressBarDrawing, progressManager.UpdateProgress);


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

public interface IProgressManager
{
    public string CurrentMessage { get; }
    public string CurrentBarDrawing { get; }
    public string CurrentProgressValue { get; }
    public string GetProgressBarDrawing(double value);
    public void UpdateProgress(IProgress progress);
}


public class ProgressManager : IProgressManager
{
    public string CurrentMessage { get; private set; }    
    public string CurrentBarDrawing { get; private set; }
    public string CurrentProgressValue { get; private set; }

    public ProgressManager()
    {
        CurrentMessage = string.Empty;
        CurrentBarDrawing = string.Empty;
        CurrentProgressValue = "0 %";        
    }
        
    public string GetProgressBarDrawing(double value)
    {
        var barPinNumber = Math.Round(value * 10);
        var barPinCounter = 0;
        var barDrawing = "";
        while (barPinCounter++ < barPinNumber)
            barDrawing += "|";
        return barDrawing;
    }

    public void UpdateProgress(IProgress progress)
    {        
        CurrentMessage = progress.Message;        
        CurrentBarDrawing = progress.BarDrawing;
        var progressPercentage = CalculateProgressPercentage(progress.Value);
        CurrentProgressValue = $"{progressPercentage} %";        
        ShowCurrentProgress();
    }

    private int CalculateProgressPercentage(double value)
    {
        return Convert.ToInt32(value * 100);
    }

    private void ShowCurrentProgress()
    {
        Console.WriteLine(CurrentMessage);
        Thread.Sleep(1000);
        Console.WriteLine($"{CurrentBarDrawing} {CurrentProgressValue}");
    }    
}

public interface IProgress
{
    public string Message { get; }
    public string BarDrawing { get; }
    public double Value { get; }
}

public class Progress : IProgress
{
    public string Message { get; }        
    public double Value { get; }
    public string BarDrawing { get; }

    public Progress(string message, double value, string barDrawing)
    {
        Message = message;
        Value = value;
        BarDrawing = barDrawing;
    }   
}

public interface IParkingLot
{
    public string Park(IVehicle vehicle);
}

public class ParkingLot : IParkingLot
{
    public string Park(IVehicle vehicle)
    {
        return vehicle.Park();                
    }
}

public interface IVehicle
{
    public string Park();
}

public class Ambulance : IVehicle
{
    public string Park()
    {
        return "The Ambulance is parked.";
    }
}

public class Car : IVehicle
{
    public string Park()
    {
        return "The Car is parked.";
    }
}

public class Truck : IVehicle
{
    public string Park()
    {
        return "The Truck is parked.";
    }
}

public class Motorcycle : IVehicle
{
    public string Park()
    {
        return "The Motorcycle is parked.";
    }
}

public class Bus : IVehicle
{
    public string Park()
    {
        return "The Bus is parked.";
    }
}