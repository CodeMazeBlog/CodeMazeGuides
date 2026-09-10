# Basic Web API Series

The six-part ASP.NET Core Web API series on Code Maze, one folder per article, in reading
order. Each folder is the previous folder plus that article's work, so a reader can start
anywhere and diff forward.

| # | Folder | Article |
|---|---|---|
| 1 | [`Database`](Database) | SQL Server With ASP.NET Core: Creating the Database |
| 2 | [`ServiceConfiguration`](ServiceConfiguration) | Service Configuration in ASP.NET Core Web API With Extension Methods |
| 3 | [`Logging`](Logging) | NLog in ASP.NET Core Web API: Logging to a File |
| 4 | [`RepositoryPatternWithEfCore`](RepositoryPatternWithEfCore) | Repository Pattern in .NET Core Web API |
| 5 | [`UsingRepositoryForGetRequests`](UsingRepositoryForGetRequests) | ASP.NET Core Web API GET Requests With a Repository |
| 6 | [`UsingRepositoryForWriteRequests`](UsingRepositoryForWriteRequests) | POST, PUT, and DELETE in ASP.NET Core Web API |

`BasicWebApiSeries.sln` at this level builds and tests all of them at once. Each article
folder also has its own solution for working through one part on its own.

## Before you run anything from part 4 onward

Create the database first. `Database/init.sql` creates `AccountOwner`, both tables and the
sample data; `Database/README.md` has the LocalDB and container commands. The connection
string in each `appsettings.json` points at LocalDB by default.

Nothing in this series calls `EnsureCreated()`. The script owns the schema, with the
explicit column lengths and `DATE` types the article documents.

## Everything targets net10.0

`Microsoft.EntityFrameworkCore.SqlServer` 10.0.11 where a project touches the database,
`NLog.Web.AspNetCore` 6.2.0 for logging, `AutoMapper` 14.0.0 from part 5 onward.

## Tests

`UsingRepositoryForWriteRequests/AccountOwnerServer.Tests` runs the repository against a
real SQL Server in a Testcontainers container, seeded with the same `init.sql`. Where
Docker is not available the tests report as **skipped with a reason**, never as passed.
