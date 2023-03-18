namespace RefactoringObjectOrientationAbusers.SwitchStatements.Incorrect
{
    public class Plane
    {
        public const int Cargo = 0;
        public const int Passenger = 1;
        public const int Military = 2;
        public int Type { get; private set; }

        public Plane(int type)
        {
            Type = type;
        }

        public double GetCapacity()
        {
            switch (Type)
            {
                case Cargo:
                    return GetCargoPlaneCapacity();
                case Military:
                    return GetMiliratyPlaneCapacity();
                case Passenger:
                    return GetPassengerPlaneCapacity();
                default:
                    throw new ArgumentOutOfRangeException($"Incorrect value: {Type}");
            }
        }

        private double GetCargoPlaneCapacity()
        {
            return 10000;
        }

        private double GetMiliratyPlaneCapacity()
        {
            return 50000;
        }

        private double GetPassengerPlaneCapacity()
        {
            return 2000;
        }
    }
}
