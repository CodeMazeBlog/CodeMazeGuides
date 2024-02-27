namespace ResolveIoptionsInsideProgramCs;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Testing;
using ResolveIoptionsInsideProgramCs.DTOs;
using System.Net.Http.Json;

public class ResolveIoptionsInsideProgramCsTests
{
    [Fact]
    public void WhenGetSettingsIncorrect_ThenSettingsAreResolved()
    {
        // Arrange
        var builder = WebApplication.CreateBuilder(new WebApplicationOptions() { });

        // Act
        var mySettingsWrapped = Program.GetSettingsIncorrect(builder);

        // Assert
        Assert.NotNull(mySettingsWrapped);
        Assert.NotNull(mySettingsWrapped.Value);
        Assert.False(string.IsNullOrWhiteSpace(mySettingsWrapped.Value.ImportantSetting));
    }

    [Fact]
    public void WhenGetSpecificValue_TheTheValueShouldBeReturned()
    {
        // Arrange
        var builder = WebApplication.CreateBuilder(new WebApplicationOptions() { });

        // Act
        var mySettings = Program.GetSpecificValue(builder);

        // Assert
        Assert.False(string.IsNullOrWhiteSpace(mySettings));
    }

    [Fact]
    public void WhenBindToSettingsModel_ThenSettingsAreBoundToModel()
    {
        // Arrange
        var builder = WebApplication.CreateBuilder(new WebApplicationOptions() { });

        // Act
        var mySettings = Program.BindToSettingsModel(builder);

        // Assert
        Assert.NotNull(mySettings);
        Assert.False(string.IsNullOrWhiteSpace(mySettings.ImportantSetting));
    }

    [Fact]
    public void WhenBindToSettingsModelAndWrapInIoptions_ThenSettingsAreWrappedInIoptions()
    {
        // Arrange
        var builder = WebApplication.CreateBuilder(new WebApplicationOptions() { });

        // Act
        var mySettingsWrapped = Program.BindToSettingsModelAndWrapInIoptions(builder);

        // Assert
        Assert.NotNull(mySettingsWrapped);
        Assert.NotNull(mySettingsWrapped.Value);
        Assert.False(string.IsNullOrWhiteSpace(mySettingsWrapped.Value.ImportantSetting));
    }

    [Fact]
    public async Task WhenRegisterAndResolveOptionsThroughServiceImplementationFactoryDelegate_ThenSettingsAreRetrieved()
    {    // Arrange
        var factory = new WebApplicationFactory<Program>();
        var tenant = "tenantA";
        var client = factory.CreateClient();
        client.DefaultRequestHeaders.Add("tenant", tenant);

        // Act
        var response = await client.GetFromJsonAsync<SettingsDto>("/api/business/get-settings");

        // Assert
        Assert.NotNull(response);
        Assert.Equal(tenant, response.Tenant);
        Assert.False(string.IsNullOrWhiteSpace(response.mySettingsValue));
    }
}