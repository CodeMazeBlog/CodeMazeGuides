namespace InequalityVsIsNot
{
    public class Vehicle
    {
        public Brand VehicleBrand { get; set; }
        public int SerialNumber { get; set; }
    }

    public enum Brand
    {
        Ford = 1,
        Toyota = 2
    }
}
