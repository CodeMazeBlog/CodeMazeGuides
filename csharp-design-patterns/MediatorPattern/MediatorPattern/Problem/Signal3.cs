namespace MediatorPattern.Problem;

public class Signal3() : SignalBase(SignalName.Signal3, TrafficDirection.NorthSouth)
{
    public void ShowGreenLight(Signal1 signal1, Signal2 signal2, Signal4 signal4)
    {
        if (Light == TrafficLight.Green)
            return;

        signal2.ShowRedLight();
        signal4.ShowRedLight();

        ChangeLight(TrafficLight.Green);

        signal1.ShowGreenLight(signal2, this, signal4);
    }

    public void ShowRedLight() => ChangeLight(TrafficLight.Red);
}