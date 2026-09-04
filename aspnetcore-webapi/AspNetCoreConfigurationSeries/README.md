# Configuration in ASP.NET Core — the series samples

This folder holds the code for the [Configuration in ASP.NET Core](https://code-maze.com/net-core-series/#configuration)
series. Each article gets its own folder with its own solution, so you can start at
the beginning or clone only the part you are reading.

| Folder | Article |
| - | - |
| `ConfigurationBasics` | [How to Use IConfiguration in ASP.NET Core](https://code-maze.com/aspnet-configuration-basic-concepts/) |
| `OptionsPattern` | [Options Pattern in ASP.NET Core With IOptions](https://code-maze.com/aspnet-configuration-options/) |
| `OptionsValidation` | [Options Validation in ASP.NET Core](https://code-maze.com/aspnet-configuration-options-validation/) |
| `ConfigurationProviders` | [ASP.NET Core Configuration Providers](https://code-maze.com/aspnet-configuration-providers/) |
| `CustomConfigurationProvider` | [Custom Configuration Provider in ASP.NET Core With EF Core](https://code-maze.com/aspnet-configuration-creating-custom-provider/) |
| `SecuringDataLocally` | [User Secrets vs Environment Variables in ASP.NET Core](https://code-maze.com/aspnet-configuration-securing-sensitive-data/) |

Every folder builds and its tests run on .NET 10:

```
cd OptionsPattern
dotnet build ProjectConfigurationDemo.sln
dotnet test ProjectConfigurationDemo.sln
```

`AspNetCoreConfigurationSeries.sln` in this folder is a convenience solution that
contains all six, so the whole series can be built and tested in one go.

## The folders are not a strict accumulation

Each folder is the end state of its own article, which is not always the previous
folder plus something new. Two steps deliberately take something away, because the
articles tell the reader to:

- `OptionsValidation` drops the **named options** that `OptionsPattern` introduces.
  Part 3 needs one options instance, not two, so `ITitleColorService.GetTitleColor()`
  loses its parameter and the `Pages:ProductPage` section goes. The two folders'
  `Services/TitleColorService.cs` files are meant to differ.
- `CustomConfigurationProvider` replaces part 4's INI registration with the EF Core
  provider rather than adding to it, so `appsettings.ini` is not carried forward.

## Running the samples that need a database

`CustomConfigurationProvider` and `SecuringDataLocally` read their configuration
from SQL Server through a custom configuration provider, which runs before anything
else in the application, so a reachable server is needed to start them.

`CustomConfigurationProvider/ProjectConfigurationDemo/appsettings.json` points at
LocalDB (`(localdb)\MSSQLLocalDB`), which ships with the Visual Studio workloads and
the SQL Server Express installer on Windows. On another platform, start a container
and point the connection string at it:

```
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=<a strong password>" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest
```

`SecuringDataLocally` ships with **no connection string in `appsettings.json` at
all** — that is the whole subject of its article. Supply it from a user secret
before running that project:

```
cd SecuringDataLocally/ProjectConfigurationDemo
dotnet user-secrets set "ConnectionStrings:sqlConnection" "Server=(localdb)\MSSQLLocalDB;Database=CodeMazeCommerce;Trusted_Connection=True;TrustServerCertificate=True"
```

or from an environment variable, using the double underscore as the separator:

```
ConnectionStrings__sqlConnection=...
```

Each of the three projects that use the Secret Manager carries its **own**
`UserSecretsId`, so their secret stores are separate — which is the point the last
article makes about user secrets being scoped to a project.

## The tests

Every folder has a test project, and the four that need no database run anywhere.

`CustomConfigurationProvider.Tests` and `SecuringDataLocally.Tests` start a real SQL
Server in a [Testcontainers](https://dotnet.testcontainers.org/) container, so they
need a running Docker daemon. Tests that need the container are marked
`[RequiresDockerFact]` and are **skipped**, not failed, when no daemon is reachable,
so `dotnet test` is green on a machine without Docker. Set
`CONFIGURATION_SERIES_REQUIRE_DOCKER=1` to turn a missing daemon into a failure
instead, which is the setting to use if you want the container tests to be
mandatory.
