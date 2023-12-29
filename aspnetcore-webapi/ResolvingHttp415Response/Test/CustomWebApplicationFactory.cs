using Microsoft.AspNetCore.Mvc.Testing;

namespace ResolvingUnsuportedMediaTypesTest;

public class CustomWebApplicationFactory<TProgram>
    : WebApplicationFactory<TProgram> where TProgram : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        base.ConfigureWebHost(builder);
    }
    protected override void ConfigureClient(HttpClient client)
    {
        base.ConfigureClient(client);
    }
}
