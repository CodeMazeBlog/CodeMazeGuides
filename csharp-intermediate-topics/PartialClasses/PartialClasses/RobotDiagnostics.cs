namespace PartialClasses;

public partial class Robot
{
    public int GetChargeRemaining()
    {
        return _chargeRemaining;
    }
    
    public void PrintDiagnostics()
    {
        Console.WriteLine($"Distance covered: {DistanceCovered}m, charge remaining: {_chargeRemaining}%");
    }
}