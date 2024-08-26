namespace MediatorPattern.Solution;

public abstract class SignalBase(ITrafficMediator mediator, SignalName name)
{
    public SignalName Name => name;

    public TrafficLight Light { get; private set; }

    public void ShowGreenLight()
    {
        mediator.RequestClearance(Name);

        ChangeLight(TrafficLight.Green);
    }

    public void ShowRedLight() => ChangeLight(TrafficLight.Red);

    private void ChangeLight(TrafficLight light)
    {
        Light = light;

        Console.WriteLine($"{Name} is {light}");
    }
}