namespace GetQuarterFromGivenDateTests;

[TestClass]
public class GetQuarterFromDateUnitTests
{
    [TestMethod]
    public void GivenADateInLeapYear_WhenQuarterEvaluated_ThenVerifyCorrectResults()
    {
        var leapYearDate = new DateTime(2024, 2, 29);
        var quarterLeapYear = CalculateQuarterMethods.CalculateQuarter(leapYearDate);
        var nonLeapYearDate = new DateTime(2023, 2, 28);
        var quarterNonLeapYear = CalculateQuarterMethods.CalculateQuarter(nonLeapYearDate);

        Assert.AreEqual(quarterLeapYear, quarterNonLeapYear);
    }

    [TestMethod]
    public void GivenADate_WhenQuarterUsingSelectionInvoked_ThenVerifyCorrectResults()
    {
        var leapYearDate = new DateTime(2024, 2, 29);
        var expectedQuarter = 1;

        var actualQuarter = CalculateQuarterMethods.CalculateQuarterUsingSelection(leapYearDate);

        Assert.AreEqual(expectedQuarter, actualQuarter);
    }

    [TestMethod]
    public void GivenADate_WhenQuarterUsingArrayLookUpInvoked_ThenVerifyCorrectResults()
    {
        var leapYearDate = new DateTime(2024, 2, 29);
        var expectedQuarter = 1;

        var actualQuarter = CalculateQuarterMethods.CalculateQuarterUsingArrayLookUp(leapYearDate);

        Assert.AreEqual(expectedQuarter, actualQuarter);
    }

    [TestMethod]
    public void GivenADate_WhenQuarterUsingLINQInvoked_ThenVerifyCorrectResults()
    {
        var leapYearDate = new DateTime(2024, 2, 29);
        var expectedQuarter = 1;

        var actualQuarter = CalculateQuarterMethods.CalculateQuarterUsingLinq(leapYearDate);

        Assert.AreEqual(expectedQuarter, actualQuarter);
    }

    [TestMethod]
    public void GivenADate_WhenQuarterRangeEvaluated_ThenVerifyCorrectDatesReturned()
    {
        var inputDate = new DateTime(2023, 12, 15);
        var expectedStartDate = new DateTime(2023, 10, 1);
        var expectedEndDate = new DateTime(2023, 12, 31);

        var actualDateRange = CalculateQuarterMethods.CalculateQuarterDates(inputDate);

        Assert.AreEqual(expectedStartDate, actualDateRange.StartQuarterDate);
        Assert.AreEqual(expectedEndDate, actualDateRange.EndQuarterDate);
    }

    [TestMethod]
    public void GivenADate_WhenFiscalQuarterEvaluated_ThenVerifyCorrectQuarterReturned()
    {
        var inputDate = new DateTime(2023, 4, 1);
        var expectedQuarter = 1;
       
        var actualQuarter = CalculateQuarterMethods.CalculateFiscalQuarter(inputDate);

        Assert.AreEqual(expectedQuarter, actualQuarter);
    }

    [TestMethod]
    public void GivenADate_WhenFiscalQuarterOffsetEvaluated_ThenVerifyCorrectQuarterReturned()
    {
        var inputDate = new DateTime(2023, 4, 15);
        var fiscalStart = new DateTime(2023, 4, 1);
        var expectedQuarter = 1;

        var actualQuarter = CalculateQuarterMethods.CalculateFiscalQuarterOffset(inputDate, fiscalStart);

        Assert.AreEqual(expectedQuarter, actualQuarter);
    }
}