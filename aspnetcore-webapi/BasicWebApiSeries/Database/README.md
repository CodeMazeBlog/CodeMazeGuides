# Database

Part 1 of the ASP.NET Core Web API series. This folder holds the SQL Server schema the
rest of the series reads and writes, and nothing else: there is no .NET project here.

`init.sql` creates the `AccountOwner` database, the `Owner` and `Account` tables, the
foreign key between them, and the sample data. It is re-runnable.

## Windows, on LocalDB

```
sqlcmd -S "(localdb)\MSSQLLocalDB" -i init.sql
```

LocalDB comes with the Visual Studio Installer's *Data storage and processing* workload
(and with SQL Server Express media). It is not part of the .NET SDK.

## Anywhere, in a container

```
docker compose up -d
sqlcmd -S localhost -U sa -P "YourStrong!Passw0rd" -C -i init.sql
```

`-C` trusts the container's self-signed certificate, which ODBC Driver 18 and the newer
`sqlcmd` builds require.

## Why the ids are fixed

The sample data hardcodes its GUIDs. Later parts of the series call endpoints with these
exact ids, so a reader who generates fresh ones cannot follow along.

## Why nothing calls EnsureCreated()

The schema comes from this script, with explicit lengths (`NVARCHAR(60)`, `NVARCHAR(100)`,
`NVARCHAR(45)`) and `DATE` columns. EF Core's default model for the same entities would
produce `nvarchar(max)` and `datetime2` instead. The script is the only thing that creates
the schema, in every folder of this series.
