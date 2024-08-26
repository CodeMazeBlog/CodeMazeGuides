namespace MediatorPattern.Problem;

public abstract class SignalBase(SignalName name)
{
    public SignalName Name => name;

    public TrafficLight Light { get; private set; }

    protected void ChangeLight(TrafficLight light)
    {
        Light = light;

        Console.WriteLine($"{Name} is {light}");
    }
}