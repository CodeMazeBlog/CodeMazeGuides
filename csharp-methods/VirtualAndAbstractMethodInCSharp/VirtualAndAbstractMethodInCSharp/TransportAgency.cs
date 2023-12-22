namespace VirtualAndAbstractMethodInCSharp
{
    public enum TransportModeType
    {
        Car,
        Plane,
        Train
    }
    internal class TransportAgency
    {
        public TransportMode CreateTransportMode(TransportModeType modeType)
        {
            return modeType switch
            {
                TransportModeType.Car => new Car(60),// Average speed in km/h
                TransportModeType.Train => new Train(4),// Fixed journey time in hours
                TransportModeType.Plane => new Plane(800),// Cruising speed in km/h
                _ => throw new ArgumentException("Invalid transport mode type."),
            };
        }
    }

    // Abstract class representing a generic transportation mode
    internal abstract class TransportMode
    {
        // Abstract method for estimating travel time
        public abstract double GetTravelTime(double distance);

        // Virtual method for calculating base fare (can be overridden)
        public virtual double CalculateBaseFare(double distance)
        {
            return distance * 0.5; // Default fare per km
        }
    }
}
