using AbstractFactoryPattern;
using AbstractFactoryPattern.Interfaces;

namespace Tests;

public class Tests
{
    [Fact]
    public void GivenThemeParkFactory_WhenCreatingAdventureThemePark_ThenCreatesAdventureRideAndShow()
    {
        IThemeParkFactory factory = new AdventureThemeParkFactory();

        var ride = factory.CreateRide();
        var show = factory.CreateShow();

        Assert.IsType<AdventureRide>(ride);

        Assert.IsType<AdventureShow>(show);
    }

    [Fact]
    public void GivenThemeParkFactory_WhenCreatingFantasyThemePark_ThenCreatesFantasyRideAndShow()
    {
        IThemeParkFactory factory = new FantasyThemeParkFactory();

        var ride = factory.CreateRide();
        var show = factory.CreateShow();

        Assert.IsType<FantasyRide>(ride);

        Assert.IsType<FantasyShow>(show);
    }
}