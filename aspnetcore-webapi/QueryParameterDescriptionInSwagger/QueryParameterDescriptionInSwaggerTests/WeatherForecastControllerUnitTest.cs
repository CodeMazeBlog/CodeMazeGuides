using QueryParameterDescriptionInSwagger.Controllers;
using Xunit;
using static QueryParameterDescriptionInSwagger.Controllers.WeatherForecastController;

namespace QueryParameterDescriptionInSwaggerTests;

public class WeatherForecastControllerUnitTest  
{   
    [Fact]
    public void WhenLimitIsZero_ThenReturnEmptyCollection()
    {
        // Arrange
        var controller = new WeatherForecastController();
        int limit = 0;
        var parameters = new Parameters()
        {
            Limit = limit
        };

        // Act
        var result = controller.Get(parameters);

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void WhenLimitIsPositive_ThenReturnCollectionWithSpecifiedCount()
    {
        // Arrange
        var controller = new WeatherForecastController();
        int limit = 5;
        var parameters = new Parameters()
        {
            Limit = limit
        };

        // Act
        var result = controller.Get(parameters);

        // Assert
        Assert.Equal(limit, result.Count());
    }
}