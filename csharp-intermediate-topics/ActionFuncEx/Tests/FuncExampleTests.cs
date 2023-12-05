namespace Tests;

public class FuncExampleTests
{
    
    [Fact]
    public void GivenAgeInTenYears_WhenPresentAgeIsProvided_ThenReturnsAgeInTenYears()
    {
        var initialAge = 5;
        var expectedAgeInTenYears = 15;
        var result = FuncExample.CalculateAgeInTenYears(initialAge);

        Assert.Equal(expectedAgeInTenYears, result);
    }
}