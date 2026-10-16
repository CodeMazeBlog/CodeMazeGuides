using System.Data.Common;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Tests;

[TestClass]
public class AsAsyncEnumerableUnitTest
{
    [TestMethod]
    public async Task GivenItemsQuery_WhenAsAsyncEnumerableIsCalled_ThenNoCommandRunsUntilEnumeration()
    {
        await using var connection = new SqliteConnection("Data Source=:memory:");
        await connection.OpenAsync();

        var counter = new ReaderCounter();
        var options = new DbContextOptionsBuilder<ItemContext>()
            .UseSqlite(connection)
            .AddInterceptors(counter)
            .Options;

        await using var context = new ItemContext(options);
        await context.Database.EnsureCreatedAsync();
        context.Items.AddRange(new Item { Name = "Keyboard" }, new Item { Name = "Mouse" });
        await context.SaveChangesAsync();
        counter.Readers = 0;

        var items = context.Items.AsNoTracking().AsAsyncEnumerable();
        await using var enumerator = items.GetAsyncEnumerator();

        Assert.AreEqual(0, counter.Readers);

        Assert.IsTrue(await enumerator.MoveNextAsync());
        Assert.AreEqual(1, counter.Readers);
        Assert.AreEqual("Keyboard", enumerator.Current.Name);
    }

    private sealed class ReaderCounter : DbCommandInterceptor
    {
        public int Readers;

        public override ValueTask<InterceptionResult<DbDataReader>> ReaderExecutingAsync(
            DbCommand command,
            CommandEventData eventData,
            InterceptionResult<DbDataReader> result,
            CancellationToken cancellationToken = default)
        {
            Readers++;
            return base.ReaderExecutingAsync(command, eventData, result, cancellationToken);
        }
    }
}
