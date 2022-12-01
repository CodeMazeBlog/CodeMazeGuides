using ValueVsReferenceTypes;
namespace ValueVsReferenceTypesTest
{
    [TestClass]
    public class UnitTest
    {
        Car car = new();
        WorkingDaysCalculator workingDaysCalculator = new();

        [TestMethod]
        public void WhenChangeCarModel_ThenMethodReturnsCorrectValue()
        {
            var expectedResults = "Toyota";
            var actualResults = car.CarModelName;

            Assert.AreEqual(expectedResults, actualResults);
        }

        [TestMethod]
        public void WhenDaysOfTheWeek_ThenMethodReturnsCorrectValue()
        {
            var expectedResults = 7;
            var actualResults = workingDaysCalculator.DaysOfTheWeek;

            Assert.AreEqual(expectedResults, actualResults);
        }

        [TestMethod]
        public void WhenWeeklyWorkDays_ThenMethodReturnsCorrectValue()
        {
            var expectedResults = 5;
            var actualResults = workingDaysCalculator.WeeklyWorkDays();

            Assert.AreEqual(expectedResults, actualResults);
        }
    }
}