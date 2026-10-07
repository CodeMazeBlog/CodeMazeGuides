using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

public class MigrationRevertTests : IDisposable
{
    private const string InitMigration = "20231209224404_Init";
    private const string HasDoorsMigration = "20231209231131_Hangar_HasDoors";

    private readonly string _dbPath = Path.Combine(Path.GetTempPath(), $"airport-{Guid.NewGuid():N}.db");

    private AirportDbContext CreateContext()
    {
        // The sample keeps its database in LocalApplicationData; the tests use a throwaway file instead.
        var db = new AirportDbContext();
        db.Database.SetConnectionString($"Data Source={_dbPath}");

        return db;
    }

    private static List<string> GetHangarColumns(AirportDbContext db)
    {
        var connection = db.Database.GetDbConnection();
        connection.Open();
        try
        {
            using var command = connection.CreateCommand();
            command.CommandText = "SELECT name FROM pragma_table_info('Hangars');";
            using var reader = command.ExecuteReader();

            var columns = new List<string>();
            while (reader.Read())
            {
                columns.Add(reader.GetString(0));
            }

            return columns;
        }
        finally
        {
            connection.Close();
        }
    }

    [Fact]
    public void WhenAllMigrationsAreApplied_ThenHangarsHasTheHasDoorsColumn()
    {
        using var db = CreateContext();

        db.Database.Migrate();

        Assert.Equal([InitMigration, HasDoorsMigration], db.Database.GetAppliedMigrations());
        Assert.Contains("HasDoors", GetHangarColumns(db));
    }

    [Fact]
    public void WhenAllMigrationsAreApplied_ThenTheSampleCanSaveAHangarWithDoors()
    {
        using (var db = CreateContext())
        {
            db.Database.Migrate();
            db.Add(new Hangar { HangarNumber = "HANGAR_01", HasDoors = true });
            db.SaveChanges();
        }

        using (var db = CreateContext())
        {
            var hangar = db.Hangars.Single();

            Assert.Equal("HANGAR_01", hangar.HangarNumber);
            Assert.True(hangar.HasDoors);
        }
    }

    [Fact]
    public void WhenDatabaseIsUpdatedToInit_ThenTheHasDoorsColumnIsGone()
    {
        using var db = CreateContext();
        db.Database.Migrate();

        db.GetService<IMigrator>().Migrate(InitMigration);

        Assert.Equal([InitMigration], db.Database.GetAppliedMigrations());
        Assert.Equal([HasDoorsMigration], db.Database.GetPendingMigrations());
        Assert.DoesNotContain("HasDoors", GetHangarColumns(db));
    }

    [Fact]
    public void WhenDatabaseIsUpdatedToZero_ThenEveryMigrationIsReverted()
    {
        using var db = CreateContext();
        db.Database.Migrate();

        db.GetService<IMigrator>().Migrate(Migration.InitialDatabase);

        Assert.Empty(db.Database.GetAppliedMigrations());
        Assert.Empty(GetHangarColumns(db));
    }

    public void Dispose()
    {
        SqliteConnection.ClearAllPools();
        File.Delete(_dbPath);
    }
}
