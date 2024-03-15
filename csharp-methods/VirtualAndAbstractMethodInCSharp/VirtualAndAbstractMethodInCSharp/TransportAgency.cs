namespace VirtualAndAbstractMethodInCSharp
{
    public enum TransportModeType
    {
        Car,
        Plane,
        Train
    }

    public class TransportAgency
    {
        public TransportMode CreateTransportMode(TransportModeType modeType)
        {
            return modeType switch
            {
                TransportModeType.Car => new Car(60),
                TransportModeType.Train => new Train(4),
                TransportModeType.Plane => new Plane(800),
                _ => throw new ArgumentException("Invalid transport mode type."),
            };
        }
    }

    public abstract class TransportMode
    {
        public abstract double GetTravelTime(double distance);

        public virtual double CalculateBaseFare(double distance)
        {
            return distance * 0.5; 
        }
    }
}
