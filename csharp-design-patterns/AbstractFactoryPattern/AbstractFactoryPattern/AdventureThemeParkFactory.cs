using AbstractFactoryPattern.Interfaces;

namespace AbstractFactoryPattern;

public class AdventureThemeParkFactory : IThemeParkFactory
{
    public IRide CreateRide()
    {
        return new AdventureRide();
    }

    public IShow CreateShow()
    {
        return new AdventureShow();
    }
}
