namespace MediatorPattern.Problem;

public class Signal2() : SignalBase(SignalName.Signal2, TrafficDirection.EastWest)
{
    public void ShowGreenLight(Signal1 signal1, Signal3 signal3, Signal4 signal4)
    {
        if (Light == TrafficLight.Green)
            return;

        signal1.ShowRedLight();
        signal3.ShowRedLight();

        ChangeLight(TrafficLight.Green);

        signal4.ShowGreenLight(signal1, this, signal3);
    }

    public void ShowRedLight() => ChangeLight(TrafficLight.Red);
}