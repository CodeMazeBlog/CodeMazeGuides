using System;
using Xunit;

namespace AccountOwnerServer.Tests;

/// <summary>
/// A fact that runs only when SQL Server integration tests are switched on with
/// CODEMAZE_SQLSERVER_TESTS=1. The tests need a working Docker daemon: Testcontainers
/// starts mcr.microsoft.com/mssql/server for them.
/// </summary>
public sealed class SqlServerFactAttribute : FactAttribute
{
    public SqlServerFactAttribute()
    {
        if (Environment.GetEnvironmentVariable("CODEMAZE_SQLSERVER_TESTS") != "1")
        {
            Skip = "Set CODEMAZE_SQLSERVER_TESTS=1 (and have Docker running) to run the SQL Server tests.";
        }
    }
}
