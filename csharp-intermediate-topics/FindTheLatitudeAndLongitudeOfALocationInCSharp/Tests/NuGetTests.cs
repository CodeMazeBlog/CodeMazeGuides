namespace Tests;
public class NuGetTests
{
    [Fact]
    public async Task GivenInvalidAddress_WhenGetLatLongWithNuGetCalled_ThenReturnsErrorMessage()
    {
        var mockMapLocationService = new Mock<IMapLocationService>();
        var invalidAddress = "Invalid Address";

        mockMapLocationService.Setup(service => service.GetLatLongFromAddressAsync(invalidAddress))
            .ThrowsAsync(new Exception("Invalid address provided"));

        var serviceUnderTest = new LatLongWithNuGet(mockMapLocationService.Object);

        var result = await serviceUnderTest.GetLatLongWithNuGet(invalidAddress);

        Assert.Contains("Error retrieving coordinates: Invalid address provided", result);
    }

    [Fact]
    public async Task GivenServerError_WhenGetLatLongWithNuGetCalled_ThenReturnsErrorMessage()
    {
        var mockMapLocationService = new Mock<IMapLocationService>();
        var validAddress = "123 Main Street";

        mockMapLocationService.Setup(service => service.GetLatLongFromAddressAsync(validAddress))
            .Throws(new HttpRequestException("Server error occurred."));

        var serviceUnderTest = new LatLongWithNuGet(mockMapLocationService.Object);

        var result = await serviceUnderTest.GetLatLongWithNuGet(validAddress);

        Assert.StartsWith("Error retrieving coordinates: Server error occurred.", result);

    }
}
