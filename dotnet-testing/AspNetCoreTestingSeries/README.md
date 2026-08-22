## Testing ASP.NET Core Applications — the series samples

This folder holds the code for the whole [Testing ASP.NET Core Applications](https://code-maze.com/asp-net-core-testing/)
series. Each article gets its own folder with its own solution, and each folder
picks up where the previous one left off, so you can start at the beginning or
jump straight to the article you are reading.

| Folder | Article |
| - | - |
| `StartingProject` | The starting point for the whole series — the `EmployeesApp` MVC application with no tests yet. Clone this one first. |
| `UnitTestingWithXUnit` | [xUnit Testing in C# and ASP.NET Core](https://code-maze.com/aspnetcore-unit-testing-xunit/) |
| `TestingMvcControllers` | [Testing Controllers with Unit Tests and Moq in ASP.NET Core](https://code-maze.com/unit-testing-controllers-aspnetcore-moq/) |
| `IntegrationTestingMvc` | [Integration Testing in ASP.NET Core](https://code-maze.com/aspnet-core-integration-testing/) |
| `TestingAntiForgeryToken` | [How to Include AntiForgeryToken for MVC Integration Testing](https://code-maze.com/aspnet-core-testing-anti-forgery-token/) |
| `UiTestingSelenium` | [Automated UI Tests with Selenium and ASP.NET Core](https://code-maze.com/selenium-aspnet-core-ui-tests/) |

Every folder builds and its tests run on .NET 10:

```
cd UnitTestingWithXUnit
dotnet build EmployeesApp.sln
dotnet test EmployeesApp.sln
```

`AspNetCoreTestingSeries.sln` in this folder is a convenience solution that
contains all six, so the whole series can be built and tested in one go.

### Running the application

`EmployeesApp` uses SQL Server and applies its migrations on startup, so set the
`sqlConnection` connection string in `appsettings.json` to a server you can reach
before running it. The unit tests and the integration tests need no database —
the integration tests swap the provider for the EF Core in-memory one.

### The Selenium UI tests

`UiTestingSelenium/EmployeesApp.AutomatedUITests` drives a real Chrome browser
against the application running on `https://localhost:5001`, so it cannot run
unattended. Start the `EmployeesApp` project first, then run those tests from
your IDE. The project is built as part of the solution but is excluded from
automated test discovery so that `dotnet test` over the solution does not try to
launch a browser. Selenium Manager, built into `Selenium.WebDriver`, downloads a
matching ChromeDriver for you — there is no driver package to keep in step with
your Chrome version.
