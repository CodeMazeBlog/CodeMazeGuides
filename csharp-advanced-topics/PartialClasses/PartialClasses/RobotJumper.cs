namespace PartialClasses;

public partial class Robot
{
    public const int JumpChargeRequired = 3;
    public const int JumpDistance = 3;
        
    public void Jump()
    {
        if (_chargeRemaining >= JumpChargeRequired)
        {
            Console.WriteLine("Performing the Jump");
            _chargeRemaining -= JumpChargeRequired;
            DistanceCovered += JumpDistance;
        }
        else
        {
            Walk();
        }
    }
}