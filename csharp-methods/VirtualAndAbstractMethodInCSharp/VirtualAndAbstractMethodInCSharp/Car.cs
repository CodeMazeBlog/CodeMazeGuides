namespace VirtualAndAbstractMethodInCSharp
{
    public class Car(double averageSpeed) : TransportMode
    {
        private readonly double _averageSpeed = averageSpeed;

        public override double GetTravelTime(double distance)
        {
            return distance / _averageSpeed;
        }

        public override double CalculateBaseFare(double distance)
        {
            return base.CalculateBaseFare(distance) + 2.5; 
        }
    }
}
