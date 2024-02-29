using JsonObjectsWithHttpClient;

namespace Tests;

public class PetTest
{
    [Fact]
    public async void GivenPetObjectHasValues_WhenPostAsStringContentIsCalled_ThenPetResultIsReturned()
    {
        var successResult = await (new PetService()).PostAsStringContent();

        Assert.NotEqual(0, successResult.Id);

        Assert.Equal("German Shepherd", successResult.Name);
    }

    [Fact]
    public async void GivenPetObjectHasValues_WhenPostAsJsonIsCalled_ThenPetResultIsReturned()
    {
        var successResult = await (new PetService()).PostAsJson();

        Assert.NotEqual(0, successResult.Id);

        Assert.Equal("German Shepherd", successResult.Name);
    }
}