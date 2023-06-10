namespace ConstVsReadonlyInCSharp
{
    public class CircleCalculator
    {
        public const double e = 2.71;
        private const double pi = 3.14;

        public double GetCerconference(double radius)
        {
            return 2 * pi * radius;
        }

        public double GetAccurateCerconference(double radius)
        {
            const double accuratePi = 3.14159265359;
            return 2 * accuratePi * radius;
        }
    }
}
