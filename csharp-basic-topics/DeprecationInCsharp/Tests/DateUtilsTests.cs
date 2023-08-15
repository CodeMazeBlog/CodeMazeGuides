using DeprecationInCsharp;

namespace Tests;

public class DateUtilsTests
{
    [Fact]
    public void WhenUsingV1Method_ThenReturns2022()
    {
        var result = DateUtils.GetCurrentYearV1();
        
        Assert.Equal(2022, result);
    }
    
    [Fact]
    public void WhenUsingV2Method_ThenReturnsCurrentYear()
    {
        var result = DateUtils.GetCurrentYearV2();
        
        Assert.Equal(DateTime.UtcNow.Year, result);
    }
}