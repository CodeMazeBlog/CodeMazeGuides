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

        public static bool operator !=(Vehicle vehicle, Vehicle otherVehicle)
        {
            if (otherVehicle is not null)
            {
                return otherVehicle.VehicleBrand != vehicle.VehicleBrand;
            }

            return false;
        }
    }
}
