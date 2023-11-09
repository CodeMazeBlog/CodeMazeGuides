using DependencyInjectionLifetimeScopes;
using Microsoft.AspNetCore.Mvc.Testing;

namespace DependencyInjectionLifetimeScopesTest
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<Startup>
    {
    }
}
