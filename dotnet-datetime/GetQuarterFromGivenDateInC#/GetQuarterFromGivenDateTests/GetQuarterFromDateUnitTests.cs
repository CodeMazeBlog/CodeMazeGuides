namespace GetQuarterFromGivenDateTests;

[TestClass]
public class GetQuarterFromDateUnitTests
{
    [TestMethod]
    public void GivenADateInLeapYear_WhenQuarterEvaluated_VerifyCorrectResults()
    {
        var leapYearDate = new DateTime(2024, 2, 29);
        var quarterLeapYear = CalculateQuarterMethods.CalculateQuarter(leapYearDate);
        var nonLeapYearDate = new DateTime(2023, 2, 28);
        var quarterNonLeapYear = CalculateQuarterMethods.CalculateQuarter(nonLeapYearDate);

        Assert.AreEqual(quarterLeapYear, quarterNonLeapYear);
    }
}