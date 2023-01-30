namespace Tests
{
    public class UnitTests
    {
        private static double _circumference;
        private static double Area(int b, int h) { return (b * h) / 2.0; }
        private static void Circumference(int r) { _circumference = 2 * 3.14 * r; }

        [Test]
        public void GivenFuncDelegate_WhenInvokingArea_CalculateAreaOfTriangle()
        {
            var areaDelegate = new Func<int, int, double>(Area);

            Assert.That(areaDelegate.Invoke(3,7), Is.EqualTo(10.5));
        }

        [Test]
        public void GivenActionDelegate_WhenInvokingDisplay_Circumference()
        {
            var circumferenceDelegate = new Action<int>(Circumference);
            circumferenceDelegate.Invoke(2);

            Assert.That(_circumference, Is.EqualTo(12.56));
        }
    }
}