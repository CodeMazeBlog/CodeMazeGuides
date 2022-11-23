using ValueVsReferenceTypes;
namespace ValueVsReferenceTypesTest
{
    [TestClass]
    public class UnitTest
    {
       readonly Car car= new();
       readonly CarModel carModel= new();
       readonly WorkingDaysCalculator workingDaysCalculator= new();

        [TestMethod]
        public void WhenChangeCarModel_ThenMethodReturnsCorrectValue()
        {
            string expectedResults = "Nissan";
            string actualResults = car.ChangeCarModel(carModel);

            Assert.AreEqual(expectedResults, actualResults);
        }

        [TestMethod]
        public void WhenDaysOfTheWeek_ThenMethodReturnsCorrectValue()
        {
            int expectedResults = 7;
            int actualResults = workingDaysCalculator.DaysOfTheWeek();

            Assert.AreEqual(expectedResults, actualResults);
        }

        [TestMethod]
        public void WhenWeeklyWorkDays_ThenMethodReturnsCorrectValue()
        {
            int expectedResults = 5;
            int actualResults = workingDaysCalculator.WeeklyWorkDays();

            Assert.AreEqual(expectedResults, actualResults);
        }
    }
}