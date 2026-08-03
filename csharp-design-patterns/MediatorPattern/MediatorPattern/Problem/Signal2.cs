namespace MediatorPattern.Problem;

public class Signal2() : SignalBase(SignalName.Signal2)
{
    public void ShowGreenLight(Signal1 signal1, Signal3 signal3)
    {
        signal1.ShowRedLight();
        signal3.ShowRedLight();

        ChangeLight(TrafficLight.Green);
    }

    public void ShowRedLight() => ChangeLight(TrafficLight.Red);
}