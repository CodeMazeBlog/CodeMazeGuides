using ActionAndFuncDelegatesInCSharp;

namespace Tests
{
    public class UnitTests
    {
        [Test]
        public void GivenFuncDelegate_WhenInvokingArea_CalculateAreaOfTriangle()
        {
            var triangle = new Triangle();

            Assert.That(triangle.AreaDelegate.Invoke(3, 7), Is.EqualTo(10.5));
        }

        [Test]
        public void GivenActionDelegate_WhenInvokingCircumference_CalculateCircumferenceOfCircle()
        {
            var circle = new Circle();
            circle.CircumferenceDelegate.Invoke(2);

            Assert.That(circle.Result, Is.EqualTo(12.56));
        }
    }
}