namespace ConstVsReadonlyInCSharp
{
    public class CircleCalculator
    {
        public const double _e = 2.71;
        private const double _pi = 3.14;

        public double GetCircumference(double radius)
        {
            return 2 * _pi * radius;
        }

        public double GetAccurateCircumference(double radius)
        {
            const double accuratePi = 3.14159265359;
            return 2 * accuratePi * radius;
        }
    }
}
