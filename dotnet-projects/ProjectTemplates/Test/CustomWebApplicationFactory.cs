using Microsoft.AspNetCore.Mvc.Testing;

namespace codemazeapi.Controllers
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<Program>
    {
    }
}
