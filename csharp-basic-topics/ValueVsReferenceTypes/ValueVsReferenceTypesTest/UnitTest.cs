using ValueVsReferenceTypes;
namespace ValueVsReferenceTypesTest
{
    [TestClass]
    public class UnitTest
    {

        WorkingDaysCalculator workingDaysCalculator = new();

        [TestMethod]
        public void WhenChangeCarModel_ThenMethodReturnsCorrectValue()
        {
            Car car = new();
            var newModelName = "Nissan";
            car.ChangeCarModel(newModelName);
            var expectedResults = "Nissan";
            var actualResults = car.ModelName;

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
            var daysInAWeek = workingDaysCalculator.DaysOfTheWeek;
            var expectedResults = 5;
            var actualResults = workingDaysCalculator.WeeklyWorkDays(daysInAWeek);

            Assert.AreEqual(expectedResults, actualResults);
        }
    }
}