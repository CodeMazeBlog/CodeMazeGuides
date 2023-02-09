namespace Guard_Clauses
{
    public class Engine
    {
        public Engine(int horsePower, int torque, int topSpeed, FuelType fuelType)
        {
            if (horsePower < 0)
            {
                throw new ArgumentException("Parameter must not be negative", nameof(horsePower));
            }

            if (torque == 0)
            {
                throw new ArgumentException("Parameter must not be zero", nameof(torque));
            }

            if (topSpeed <= 0)
            {
                throw new ArgumentException("Parameter must not be negative or zero", nameof(topSpeed));
            }

            if (fuelType != FuelType.Diesel || fuelType != FuelType.Petrol)
            {
                throw new ArgumentException("Fuel type must be either diesel or petrol", nameof(fuelType));
            }

            HorsePower = horsePower;
            Torque = torque;
            TopSpeed = topSpeed;
            FuelType = fuelType;
        }

        public int HorsePower { get; }
        public int Torque { get; }
        public int TopSpeed { get; }
        public FuelType FuelType { get; }
    }
}
