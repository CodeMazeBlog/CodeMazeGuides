namespace PartialClasses;

public partial class Robot
{
    private const int JumpChargeRequired = 5;
    private const int JumpDistance = 5;
        
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