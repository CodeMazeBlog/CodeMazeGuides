namespace PartialClasses;

public partial class Robot
{
    public int DistanceCovered { get; private set; }
    
    private int _chargeRemaining;
    
    public void Recharge()
    {
        _chargeRemaining = 100;
    }
}