namespace PartialClasses;

public partial class Robot
{
    public const int WalkChargeRequired = 1;
    public const int WalkDistance = 1;
        
    public void Walk()
    {
        if (_chargeRemaining < WalkChargeRequired) return;
        
        Console.WriteLine("Performing the Walk");
        _chargeRemaining -= WalkChargeRequired;
        DistanceCovered += WalkDistance;
    }
}