namespace VirtualAndAbstractMethodInCSharp
{
    // Class representing a car
    internal class Car(double averageSpeed) : TransportMode
    {
        private readonly double averageSpeed = averageSpeed;

        public override double GetTravelTime(double distance)
        {
            return distance / averageSpeed;
        }

        // Override base fare calculation specific to cars (add fuel cost etc.)
        public override double CalculateBaseFare(double distance)
        {
            return base.CalculateBaseFare(distance) + 2.5; // Add fixed fuel cost
        }
    }
}
