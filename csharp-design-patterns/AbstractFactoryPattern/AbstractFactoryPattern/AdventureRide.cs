using AbstractFactoryPattern.Interfaces;

namespace AbstractFactoryPattern;

public class AdventureRide : IRide
{
    public void Start()
    {
        Console.WriteLine("Starting the Adventure Ride.");
    }
}
