using PlugInBase;

namespace TemperatureCommand;

public class TemperatureCommand : ICommand
{
    public string Name { get => "temperature"; }
    public string Description { get => "Displays high and low temperatures for the users location."; }

    public int Invoke()
    {
        Console.WriteLine("In your area, there will be high of 84F and a low of 69F.");

        return 0;
    }
}