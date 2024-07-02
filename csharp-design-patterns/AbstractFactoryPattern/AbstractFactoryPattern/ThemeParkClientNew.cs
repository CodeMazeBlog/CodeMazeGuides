using AbstractFactoryPattern.Interfaces;

namespace AbstractFactoryPattern;

public class ThemeParkClientNew
{
    private readonly IRide _ride;
    private readonly IShow _show;

    public ThemeParkClientNew(IThemeParkFactory factory)
    {
        _ride = factory.CreateRide();
        _show = factory.CreateShow();
    }

    public void EnjoyThemePark()
    {
        _ride.Start();
        _show.Begin();
    }
}
