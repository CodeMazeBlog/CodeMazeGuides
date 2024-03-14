namespace Tests;
public class NuGetTests
{
    [Fact]
    public void GivenInvalidAddress_WhenGetLatLongWithNuGetCalled_ThenReturnsErrorMessage()
    {
        var mockMapLocationService = new Mock<IMapLocationService>();
        var invalidAddress = "Invalid Address";

        mockMapLocationService.Setup(service => service.GetLatLongFromAddress(invalidAddress))
            .Throws(new Exception("Invalid address provided"));

        var serviceUnderTest = new LatLongWithNuGet(mockMapLocationService.Object);

        var result = serviceUnderTest.GetLatLongWithNuGet(invalidAddress);

        Assert.Contains("Error retrieving coordinates: Invalid address provided", result);
    }

    [Fact]
    public void GivenServerError_WhenGetLatLongWithNuGetCalled_ThenReturnsErrorMessage()
    {
        var mockMapLocationService = new Mock<IMapLocationService>();
        var validAddress = "123 Main Street";

        mockMapLocationService.Setup(service => service.GetLatLongFromAddress(validAddress))
            .Throws(new HttpRequestException("Server error occurred."));

        var serviceUnderTest = new LatLongWithNuGet(mockMapLocationService.Object);

        var result = serviceUnderTest.GetLatLongWithNuGet(validAddress);

        Assert.StartsWith("Error retrieving coordinates:", result);

    }
}
