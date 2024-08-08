namespace MediatorPattern.Solution;

public abstract class SignalBase(SignalName name, TrafficDirection direction) : ISignal
{
    public SignalName Name => name;

    public TrafficDirection Direction => direction;

    public TrafficLight Light { get; private set; }

    public void ShowGreenLight() => ChangeLight(TrafficLight.Green);

    public void ShowRedLight() => ChangeLight(TrafficLight.Red);

    private void ChangeLight(TrafficLight light)
    {
        Light = light;

        Console.WriteLine($"{Name} is {light}");
    }
}