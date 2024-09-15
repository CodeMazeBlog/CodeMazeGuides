using MediatorPattern;
using MediatorPattern.Problem;

namespace MediatorPatternTests;

public class TrafficControlWithoutMediatorTests
{
    [Fact]
    public void GivenTrafficControl_WhenNotUsingMediator_ThenFacesChaoticDependencies()
    {
        var signal1 = new Signal1();
        var signal2 = new Signal2();
        var signal4 = new Signal4();

        signal1.ShowGreenLight(signal2, signal4);

        Assert.Equal(TrafficLight.Red, signal2.Light);
        Assert.Equal(TrafficLight.Red, signal4.Light);
        Assert.Equal(TrafficLight.Green, signal1.Light);
    }
}