namespace PartialClasses;

public partial class Robot
{
    private const int WalkChargeRequired = 1;
    private const int WalkDistance = 1;
        
    public void Walk()
    {
        if (_chargeRemaining >= WalkChargeRequired)
        {
            Console.WriteLine("Performing the Walk");
            _chargeRemaining -= WalkChargeRequired;
            DistanceCovered += WalkDistance;
        }
    }
}