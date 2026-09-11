## Advanced REST Concepts in ASP.NET Core Web API: the series samples

This folder holds the code for the whole advanced REST concepts series: paging,
filtering, searching, sorting, data shaping and HATEOAS, built on one
`AccountOwnerServer` Web API. Each article gets its own folder with its own
solution, and each folder picks up where the previous one left off, so you can
start at the beginning or jump straight to the article you are reading.

| Folder | Article |
| - | - |
| `StartingProject` | The starting point for the whole series: the `AccountOwnerServer` Web API with no paging yet. Clone this one first. |
| `Paging` | [Pagination in ASP.NET Core Web API: How to Implement Paging](https://code-maze.com/paging-aspnet-core-webapi/) |
| `Filtering` | [Filtering Data in ASP.NET Core Web API](https://code-maze.com/filtering-aspnet-core-webapi/) |
| `Searching` | [Searching in ASP.NET Core Web API With Query Parameters](https://code-maze.com/searching-aspnet-core-webapi/) |
| `Sorting` | [Sorting in ASP.NET Core Web API With a Dynamic OrderBy](https://code-maze.com/sorting-aspnet-core-webapi/) |
| `DataShaping` | [Data Shaping in ASP.NET Core Web API](https://code-maze.com/data-shaping-aspnet-core-webapi/) |
| `Hateoas` | [HATEOAS in ASP.NET Core Web API](https://code-maze.com/hateoas-aspnet-core-web-api/) |

Every folder builds and its tests run on .NET 10:

```
cd Paging
dotnet build AccountOwnerServer.sln
dotnet test AccountOwnerServer.sln
```

`AdvancedRestConceptsSeries.sln` in this folder is a convenience solution that
contains all seven, so the whole series can be built and tested in one go.

### Running the application

The sample uses SQL Server on EF Core 10. On Windows the connection string in
`appsettings.json` points at LocalDB and needs no setup. Anywhere else, one line
gets you a server:

```
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=Str0ng!Passw0rd" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest
```

Then point `sqlconnection:connectionString` at it and run
`_SqlServer_Init_Script/init.sql`, which creates the two tables and seeds the
five owners and eight accounts the articles use in their examples.

### The tests

Each article folder carries an `AccountOwnerServer.Tests` project. Most of the
tests need nothing but the assembly under test: the page-size clamp, the year
range validation, the search extension, the sort helper and the data shaper are
all exercised in memory.

A smaller set of repository tests runs against a real SQL Server that
[Testcontainers](https://dotnet.testcontainers.org/) starts for the duration of
the test. Those need a working Docker daemon, so they are **skipped unless you
opt in**:

```
CODEMAZE_SQLSERVER_TESTS=1 dotnet test AccountOwnerServer.sln
```

Without the variable they report as skipped and the rest of the suite still
runs, which is what happens on CI.
