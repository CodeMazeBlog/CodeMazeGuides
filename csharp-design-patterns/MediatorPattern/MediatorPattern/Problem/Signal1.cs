namespace MediatorPattern.Problem;

public class Signal1() : SignalBase(SignalName.Signal1)
{
    public void ShowGreenLight(Signal2 signal2, Signal4 signal4)
    {
        signal2.ShowRedLight();
        signal4.ShowRedLight();

        ChangeLight(TrafficLight.Green);
    }

    public void ShowRedLight() => ChangeLight(TrafficLight.Red);
}