using MediatorPattern;
using MediatorPattern.Solution;

namespace MediatorPatternTests;

public class TrafficControlWithMediatorTests
{
    [Fact]
    public void GivenTrafficControl_WhenUsingMediator_ThenDealsWithSimplerDependencies()
    {
        var mediator = new TrafficMediator();

        var signal1 = new Signal1(mediator);
        var signal2 = new Signal2(mediator);
        var signal3 = new Signal3(mediator);
        var signal4 = new Signal4(mediator);

        mediator.Register(signal1, signal2, signal3, signal4);

        signal1.ShowGreenLight();

        Assert.Equal(TrafficLight.Red, signal2.Light);
        Assert.Equal(TrafficLight.Red, signal4.Light);
        Assert.Equal(TrafficLight.Green, signal1.Light);
    }
}