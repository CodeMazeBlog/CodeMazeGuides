namespace MediatorPattern.Problem;

public abstract class SignalBase(SignalName name, TrafficDirection direction)
{
    public SignalName Name => name;

    public TrafficDirection Direction => direction;

    public TrafficLight Light { get; protected set; }

    protected void ChangeLight(TrafficLight light)
    {
        Light = light;

        Console.WriteLine($"{Name} is {light}");
    }
}