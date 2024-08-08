namespace MediatorPattern.Problem;

public class Signal1() : SignalBase(SignalName.Signal1, TrafficDirection.NorthSouth)
{
    public void ShowGreenLight(Signal2 signal2, Signal3 signal3, Signal4 signal4)
    {
        if (Light == TrafficLight.Green) 
            return;

        signal2.ShowRedLight();
        signal4.ShowRedLight();

        ChangeLight(TrafficLight.Green);

        signal3.ShowGreenLight(this, signal2, signal4);
    }

    public void ShowRedLight() => ChangeLight(TrafficLight.Red);
}