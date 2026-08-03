using Ardalis.GuardClauses;

namespace Guard_Clauses
{
    public class Engine
    {
        public Engine(int horsePower, int cylinders, string cylinderLayout, int topSpeed, FuelType fuelType)
        {
            HorsePower = Guard.Against.Negative(horsePower);
            Cylinders = Guard.Against.NegativeOrZero(cylinders);
            CylinderLayout = Guard.Against.NullOrWhiteSpace(cylinderLayout);
            TopSpeed = Guard.Against.Zero(topSpeed);
            FuelType = Guard.Against.PetrolEngine(fuelType);
        }

        public int HorsePower { get; }
        public int Cylinders { get; }
        public string CylinderLayout { get; }
        public int TopSpeed { get; }
        public FuelType FuelType { get; }
    }
}
