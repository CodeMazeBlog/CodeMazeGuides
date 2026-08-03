using Microsoft.AspNetCore.Mvc.Testing;
using QueryStringsApi;

namespace Tests;

public class Api : WebApplicationFactory<Program>
{
    private readonly string _environment;

    public Api(string environment = "Development")
    {
        _environment = environment;
    }
}