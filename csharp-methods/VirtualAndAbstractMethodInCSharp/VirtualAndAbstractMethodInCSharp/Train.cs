namespace VirtualAndAbstractMethodInCSharp
{    
    public class Train(double fixedJourneyTime) : TransportMode
    {
        private double fixedJourneyTime = fixedJourneyTime;

        public override double GetTravelTime(double distance)
        {
            return fixedJourneyTime; 
        }

        public override double CalculateBaseFare(double distance)
        {
            var baseFare = base.CalculateBaseFare(distance);
            
            if (distance > 500)
            {
                baseFare *= 0.9;            
            }
            
            return baseFare;
        }
    }
}
