namespace ConstVsReadonlyInCSharp
{
    public class CircleCalculator
    {
        public const double E = 2.71;
        private const double Pi = 3.14;

        public double GetCircumference(double radius)
        {
            return 2 * Pi * radius;
        }

        public double GetAccurateCircumference(double radius)
        {
            const double accuratePi = 3.14159265359;

            return 2 * accuratePi * radius;
        }
    }
}
