using GoogleSheetsAPI;
using Microsoft.AspNetCore.Mvc.Testing;

namespace GoogleSheetsAPITest
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<Startup>
    {
    }
}
