namespace VirtualAndAbstractMethodInCSharp
{
    // Class representing a plane
    internal class Plane(double cruisingSpeed) : TransportMode
    {
        private readonly double cruisingSpeed = cruisingSpeed;

        public override double GetTravelTime(double distance)
        {
            return distance / cruisingSpeed + 0.5; // Add 30 minutes for takeoff/landing
        }

        // Override base fare calculation specific to planes (tiered pricing based on distance)
        public override double CalculateBaseFare(double distance)
        {
            if (distance < 500)
            {
                return 100; // Short distance fixed fare
            }
            else if (distance < 1000)
            {
                return 150; // Medium distance fixed fare
            }
            else
            {
                return distance * 0.2; // Longer distance per-km pricing
            }
        }
    }
}