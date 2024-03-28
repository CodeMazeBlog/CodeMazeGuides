using GetFirstDayOfWeekDateInCSharp;

namespace GetFirstDayOfWeekDateInCSharpTests;

[TestClass]
public class GetFirstDayOfWeekDateUnitTests
{
    [TestMethod]
    public void GivenTheYearAndWeek_WhenFirstDateOfWeekCalculated_ThenVerifyTheCorrectDateReturned()
    {
        var year = 2020;
        var week = 1;
        var expectedDate = new DateTime(2019, 12, 30);

        var actualDate = FirstDayOfWeekMethods.FirstDateOfWeekISO8601(year, week);

        Assert.IsInstanceOfType(actualDate, typeof(DateTime));
        Assert.AreEqual(expectedDate, actualDate);
    }
}