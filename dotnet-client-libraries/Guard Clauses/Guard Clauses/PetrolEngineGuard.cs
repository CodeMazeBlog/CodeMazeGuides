using Guard_Clauses;

namespace Ardalis.GuardClauses
{
    public static class PetrolEngineGuard
    {
        public static FuelType PetrolEngine(this IGuardClause guardClause, FuelType fuelType)
        {
            if (fuelType == FuelType.Petrol)
            {
                throw new ArgumentException("Fuel type cannot be petrol!", nameof(fuelType));
            }

            return fuelType;
        }
    }
}
