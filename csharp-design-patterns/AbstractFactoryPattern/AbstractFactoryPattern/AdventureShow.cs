using AbstractFactoryPattern.Interfaces;

namespace AbstractFactoryPattern;

public class AdventureShow : IShow
{
    public void Begin()
    {
        Console.WriteLine("Beginning the Adventure Show.");
    }
}
