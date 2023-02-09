namespace Guard_Clauses
{
    public class Engine
    {
        public Engine(int horsePower, int cylinders, string cylinderLayout, int topSpeed, FuelType fuelType)
        {
            if (horsePower < 0)
            {
                throw new ArgumentException($"'{nameof(horsePower)}' cannot not be negative", nameof(horsePower));
            }

            if (cylinders <= 0)
            {
                throw new ArgumentException($"'{nameof(cylinders)}' cannot be negative or zero", nameof(cylinders));
            }

            if (string.IsNullOrWhiteSpace(cylinderLayout))
            {
                throw new ArgumentException($"'{nameof(cylinderLayout)}' cannot be null or whitespace.", nameof(cylinderLayout));
            }

            if (topSpeed == 0)
            {
                throw new ArgumentException($"'{nameof(topSpeed)}' cannot be zero", nameof(topSpeed));
            }

            if (fuelType != FuelType.Diesel || fuelType != FuelType.Petrol)
            {
                throw new ArgumentException("Fuel type must be either diesel or petrol", nameof(fuelType));
            }

            HorsePower = horsePower;
            Cylinders = cylinders;
            CylinderLayout = cylinderLayout;
            TopSpeed = topSpeed;
            FuelType = fuelType;
        }

        public int HorsePower { get; }
        public int Cylinders { get; }
        public string CylinderLayout { get; }
        public int TopSpeed { get; }
        public FuelType FuelType { get; }
    }
}
