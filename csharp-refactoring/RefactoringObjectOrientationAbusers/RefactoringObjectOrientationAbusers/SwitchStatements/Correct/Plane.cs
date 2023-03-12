namespace RefactoringObjectOrientationAbusers.SwitchStatements.Correct
{
    public abstract class Plane
    {
        public const int Cargo = 0;
        public const int Passenger = 1;
        public const int Military = 2;

        public abstract int Type { get; }
        public abstract double GetCapacity();

        public static Plane Create(int type)
        {
            return type switch
            {
                Cargo => new CargoPlane(),
                Passenger => new PassengerPlane(),
                Military => new MilitaryPlane(),
                _ => throw new ArgumentOutOfRangeException($"Incorrect value: {type}")
            };
        }
    }
}
