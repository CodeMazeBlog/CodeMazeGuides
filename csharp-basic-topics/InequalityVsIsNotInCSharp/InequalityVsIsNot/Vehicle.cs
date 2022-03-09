namespace InequalityVsIsNot
{
    public class Vehicle
    {
        public Brand VehicleBrand { get; set; }
        public int SerialNumber { get; set; }

        public static bool operator ==(Vehicle vehicle, Vehicle otherVehicle)
        {
            if (otherVehicle is not null)
            {
                return otherVehicle.VehicleBrand == vehicle.VehicleBrand;
            }

            return false;
        }

        public static bool operator !=(Vehicle vehicle1, Vehicle vehicle2)
        {
            if (vehicle2 is not null)
            {
                return vehicle2.VehicleBrand != vehicle1.VehicleBrand;
            }

            return false;
        }
    }
}
