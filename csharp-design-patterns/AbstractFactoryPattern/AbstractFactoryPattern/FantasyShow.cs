using AbstractFactoryPattern.Interfaces;

namespace AbstractFactoryPattern;

public class FantasyShow : IShow
{
    public void Begin()
    {
        Console.WriteLine("Beginning the Fantasy Show.");
    }
}
