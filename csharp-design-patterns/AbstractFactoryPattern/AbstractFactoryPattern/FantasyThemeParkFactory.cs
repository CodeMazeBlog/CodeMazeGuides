using AbstractFactoryPattern.Interfaces;

namespace AbstractFactoryPattern;

public class FantasyThemeParkFactory : IThemeParkFactory
{
    public IRide CreateRide()
    {
        return new FantasyRide();
    }

    public IShow CreateShow()
    {
        return new FantasyShow();
    }
}
