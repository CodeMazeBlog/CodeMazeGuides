namespace MediatorPattern.Problem;

public class Signal4() : SignalBase(SignalName.Signal4, TrafficDirection.EastWest)
{
    public void ShowGreenLight(Signal1 signal1, Signal2 signal2, Signal3 signal3)
    {
        if (Light == TrafficLight.Green)
            return;

        signal1.ShowRedLight();
        signal3.ShowRedLight();

        ChangeLight(TrafficLight.Green);

        signal2.ShowGreenLight(signal1, signal3, this);
    }

    public void ShowRedLight() => ChangeLight(TrafficLight.Red);
}