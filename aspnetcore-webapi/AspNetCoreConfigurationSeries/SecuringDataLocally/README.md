# SecuringDataLocally

Sample for [User Secrets vs Environment Variables in ASP.NET Core](https://code-maze.com/aspnet-configuration-securing-sensitive-data/).

The code is the same application as `CustomConfigurationProvider`, with one
deliberate difference: **`appsettings.json` carries no `ConnectionStrings` section**.
That is the article's subject. `Program.cs` still reads
`ConnectionStrings:sqlConnection` and hands it to the EF Core configuration provider,
so the application does not start until the value is supplied from outside the file.

Supply it as a user secret:

```
cd ProjectConfigurationDemo
dotnet user-secrets set "ConnectionStrings:sqlConnection" "Server=(localdb)\MSSQLLocalDB;Database=CodeMazeCommerce;Trusted_Connection=True;TrustServerCertificate=True"
```

or as an environment variable, where `__` is the separator that becomes `:` in the
configuration key path:

```
set "ConnectionStrings__sqlConnection=Server=(localdb)\MSSQLLocalDB;Database=CodeMazeCommerce;Trusted_Connection=True;TrustServerCertificate=True"   :: cmd
$env:ConnectionStrings__sqlConnection = "Server=(localdb)\MSSQLLocalDB;Database=CodeMazeCommerce;Trusted_Connection=True;TrustServerCertificate=True" # PowerShell
export ConnectionStrings__sqlConnection="Server=localhost;Database=CodeMazeCommerce;User Id=sa;Password=<a strong password>;TrustServerCertificate=True"  # bash
```

This project has its **own** `UserSecretsId`, separate from the other two projects in
the series that use the Secret Manager, so a secret set here is not visible to them.

The tests supply the connection string through configuration and point it at a
Testcontainers SQL Server container. They never put it back into `appsettings.json`.
Tests marked `[RequiresDockerFact]` are skipped when no Docker daemon is reachable;
set `CONFIGURATION_SERIES_REQUIRE_DOCKER=1` to make a missing daemon a failure.
