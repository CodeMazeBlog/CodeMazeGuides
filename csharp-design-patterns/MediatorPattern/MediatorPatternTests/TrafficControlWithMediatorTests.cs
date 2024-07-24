using MediatorPattern;
using MediatorPattern.Solution;

namespace MediatorPatternTests;

public class TrafficControlWithMediatorTests
{
    [Fact]
    public void GivenTrafficControl_WhenUsingMediator_ThenDealsWithSimplerDependencies()
    {
        var signal1 = new Signal1();
        var signal2 = new Signal2();
        var signal3 = new Signal3();
        var signal4 = new Signal4();

        var mediator = new TrafficMediator();
        mediator.Register(signal1, signal2, signal3, signal4);

        mediator.ShowGreenLight(SignalName.Signal1);

        Assert.Equal(TrafficLight.Red, signal2.Light);
        Assert.Equal(TrafficLight.Red, signal4.Light);
        Assert.Equal(TrafficLight.Green, signal1.Light);
        Assert.Equal(TrafficLight.Green, signal3.Light);
    }
}