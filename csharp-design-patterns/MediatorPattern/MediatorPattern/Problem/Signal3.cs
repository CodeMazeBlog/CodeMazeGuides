namespace MediatorPattern.Problem;

public class Signal3() : SignalBase(SignalName.Signal3)
{
    public void ShowGreenLight(Signal2 signal2, Signal4 signal4)
    {
        signal2.ShowRedLight();
        signal4.ShowRedLight();

        ChangeLight(TrafficLight.Green);
    }

    public void ShowRedLight() => ChangeLight(TrafficLight.Red);
}