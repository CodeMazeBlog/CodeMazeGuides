namespace VirtualAndAbstractMethodInCSharp
{
    public class Plane(double cruisingSpeed) : TransportMode
    {
        private readonly double _cruisingSpeed = cruisingSpeed;

        public override double GetTravelTime(double distance)
        {
            return distance / _cruisingSpeed + 0.5; 
        }

        public override double CalculateBaseFare(double distance)
        {
            if (distance < 500)
            {
                return 100; 
            }
            else if (distance < 1000)
            {
                return 150; 
            }
            else
            {
                return distance * 0.2; 
            }
        }
    }
}