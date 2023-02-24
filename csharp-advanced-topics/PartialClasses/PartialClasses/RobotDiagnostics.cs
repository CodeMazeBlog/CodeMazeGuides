namespace PartialClasses;

public partial class Robot
{
    public void PrintDiagnostics()
    {
        Console.WriteLine($"Distance covered: {DistanceCovered}m, charge remaining: {_chargeRemaining}%");
    }
}