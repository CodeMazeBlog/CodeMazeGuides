namespace ActionAndFuncDelegatesInCSharp
{
    public class Circle
    {
        public Action<int> CircumferenceDelegate { get; set; } = new Action<int>(Circumference);
        public double Result { get { return _circumference; } }

        private static double _circumference;

        public static void Circumference(int r)
        {
            _circumference = 2 * 3.14 * r;
        }
    }
}
