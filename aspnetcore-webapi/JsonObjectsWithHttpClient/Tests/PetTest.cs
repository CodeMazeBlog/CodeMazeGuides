using JsonObjectsWithHttpClient.Controllers;

namespace Tests;

public class PetTest
{
    [Fact]
    public async void GivenPetObjectHasValues_WhenPetControllerIsCalled_ThenPetResultIsReturned()
    {
        var petController = new PetController();

        var successResult = await petController.Post();

        Assert.NotEqual(0, successResult.id);

        Assert.Equal("German Shepherd", successResult.name);
    }
}