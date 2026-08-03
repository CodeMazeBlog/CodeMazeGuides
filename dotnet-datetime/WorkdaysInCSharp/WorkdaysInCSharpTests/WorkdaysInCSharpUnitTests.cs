namespace WorkdaysInCSharpTests;

[TestClass]
public class WorkdaysInCSharpUnitTests
{
    [TestMethod]
    public void GivenTwoDateTimeValues_WhenCalculateBusinessDaysinvoked_ThenVerifyAccurateNumberOfWeekdays()
    {
        var startDate = new DateTime(2024, 1, 1);
        var endDate = new DateTime(2024, 1, 15);
        var expectedWeekdays = 10;

        var actualWeekdays = WorkdaysInCSharpMethods.CalculateBusinessDays(startDate, endDate);

        Assert.IsInstanceOfType(actualWeekdays, typeof(int));
        Assert.AreEqual(expectedWeekdays, actualWeekdays);
    }

    [TestMethod]
    public void GivenTwoDates_WhenCalculateBusinessDaysMethodInvoked_ThenVerifyReturnsZero()
    {
        var startDate = new DateTime(2024, 1, 15);
        var endDate = new DateTime(2024, 1, 1);

        var actualWeekdays = WorkdaysInCSharpMethods.CalculateBusinessDays(startDate, endDate);

        Assert.AreEqual(0, actualWeekdays);
    }

    [TestMethod]
    public void GivenSameDates_WhenCalculateBusinessDaysMethodInvoked_ThenVerifyReturnsZero()
    {
        var date = new DateTime(2024, 1, 1);

        var actualWeekdays = WorkdaysInCSharpMethods.CalculateBusinessDays(date, date);

        Assert.AreEqual(0, actualWeekdays);
    }

    [TestMethod]
    public void GivenNumberOfDaysAndDate_WhenAddWorkdaysInvoked_ThenVerifyCorrectResults()
    {
        var startDate = new DateTime(2024, 1, 1);
        var expectedDate = new DateTime(2024, 1, 15);
        var daysToAdd = 10;

        var actualDate = WorkdaysInCSharpMethods.AddWorkDays(startDate, daysToAdd);

        Assert.IsInstanceOfType(actualDate, typeof(DateTime));
        Assert.AreEqual(expectedDate, actualDate);
    }

    [TestMethod]
    public async Task GivenNumberOfDaysAndDate_WhenAddWorkDaysExcludingHolidaysInvoked_ThenVerifyCorrectResultsAsync()
    {
        var startDate = new DateTime(2024, 1, 1);
        var expectedDate = new DateTime(2024, 1, 16);
        var daysToAdd = 10;
        var countryCode = "US";

        var actualDate = await WorkdaysInCSharpMethods.AddWorkDaysExcludingHolidaysAsync(startDate, daysToAdd, countryCode);

        Assert.IsInstanceOfType(actualDate, typeof(DateTime));
        Assert.AreEqual(expectedDate, actualDate);
    }

    [TestMethod]
    public async Task GivenTwoDateTimeValues_WhenCalculateBusinessDaysExcludingHolidaysInvoked_ThenVerifyAccurateNumberOfWeekdaysAsync()
    {
        var startDate = new DateTime(2024, 1, 1);
        var endDate = new DateTime(2024, 1, 16);
        var expectedWeekdays = 9;
        var countryCode = "US";

        var actualWeekdays = await WorkdaysInCSharpMethods.CalculateBusinessDaysExcludingHolidaysAsync(startDate, endDate, countryCode);

        Assert.IsInstanceOfType(actualWeekdays, typeof(int));
        Assert.AreEqual(expectedWeekdays, actualWeekdays);
    }

    [TestMethod]
    public void GivenTwoDateTimeValues_WhenIsWorkingDayInvoked_ThenVerifyAccurateResults()
    {
        var firstDate = new DateTime(2024, 1, 1);
        var secondDate = new DateTime(2024, 1, 6);

        Assert.IsTrue(WorkdaysInCSharpMethods.IsWorkDay(firstDate));
        Assert.IsFalse(WorkdaysInCSharpMethods.IsWorkDay(secondDate));
    }
}