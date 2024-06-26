using AbstractFactoryPattern.Interfaces;

namespace AbstractFactoryPattern;

public class FantasyRide : IRide
{
    public void Start()
    {
        Console.WriteLine("Starting the Fantasy Ride.");
    }
}
