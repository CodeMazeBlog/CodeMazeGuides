using ValueObjects.ValueObjects;

namespace Tests;

public class RouteEqualityUnitTest
{
    [Fact]
    public void GivenTwoRoutes_WhenTheyHaveTheSameStops_ThenTheyShouldBeEqual()
    {
        Station[] stops = [new("JFK", "John F. Kennedy International Airport"), new("YVR", "Vancouver International Airport")];
        Station[] sameStops = [new("JFK", "John F. Kennedy International Airport"), new("YVR", "Vancouver International Airport")];

        Assert.Equal(new Route(stops), new Route(sameStops));
        Assert.Single(new HashSet<Route> { new(stops), new(sameStops) });
    }
}
