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

        public static bool operator !=(Vehicle person1, Vehicle person2)
        {
            if (person2 is not null)
            {
                return person2.VehicleBrand != person1.VehicleBrand;
            }

            return false;
        }
    }
}
