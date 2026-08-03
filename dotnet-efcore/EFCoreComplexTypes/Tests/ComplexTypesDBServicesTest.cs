using EFCoreComplexTypes;

namespace Tests;

public class ComplexTypesDBServicesTest
{
    private readonly ComplexTypesDBService _complexTypesDBService = new();

    [Fact]
    public async void WhenGetComplexTypeOwningEntityIsCalled_ThenReturnsAddress()
    {
        var user = await _complexTypesDBService.GetComplexTypeOwningEntity(1);

        Assert.NotNull(user);
        Assert.Equal("Luther", user.UserName);
        Assert.NotNull(user.Address);
        Assert.Equal("Slessor Way", user.Address.Street);
        Assert.Equal("Bendel", user.Address.City);
        Assert.Equal("Rivers", user.Address.State);
        Assert.Equal("504103", user.Address.PostalCode);
        Assert.Equal("Nigeria", user.Address.Country);
    }

    [Fact]
    public async void WhenGetComplexTypeFromOwningEntityIsCalled_ThenReturnsAddress()
    {
        var address = await _complexTypesDBService.GetComplexTypeFromOwningEntity(1);

        Assert.NotNull(address);
        Assert.Equal("Slessor Way", address.Street);
        Assert.Equal("Bendel", address.City);
        Assert.Equal("Rivers", address.State);
        Assert.Equal("504103", address.PostalCode);
        Assert.Equal("Nigeria", address.Country);
    }
}