using Microsoft.AspNetCore.Mvc.Testing;

namespace Tests;

public class DynamicTenantIntegrationTest(WebApplicationFactory<Program> factory) : IClassFixture<WebApplicationFactory<Program>>
{
    [Theory]
    [InlineData("/api/tenants/create?tenantName=CustomerD&urlPrefix=customer-d")]
    public async Task WhenCreateDynamicTenant_ThenSuccess(string url)
    {
        var client = factory.CreateClient();
        var response = await client.PostAsync(url, new FormUrlEncodedContent(new Dictionary<string, string>()));

        response.EnsureSuccessStatusCode();
        
        var body = await response.Content.ReadAsStringAsync();
        
        Assert.Equal($"Tenant 'CustomerD' created", body);
    }
}