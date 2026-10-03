using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using ValueObjects.Entities;
using ValueObjects.Persistence;
using ValueObjects.ValueObjects;

namespace Tests;

public class PersistenceUnitTest
{
    [Fact]
    public async Task GivenASavedPayment_WhenQueryingByMoney_ThenItIsFound()
    {
        var cancellationToken = TestContext.Current.CancellationToken;
        await using var connection = new SqliteConnection("Data Source=:memory:");
        await connection.OpenAsync(cancellationToken);
        var options = new DbContextOptionsBuilder<PaymentsDbContext>().UseSqlite(connection).Options;

        await using (var context = new PaymentsDbContext(options))
        {
            await context.Database.EnsureCreatedAsync(cancellationToken);
            context.Payments.Add(new Payment(Money.Create(100, "usd").Value));
            await context.SaveChangesAsync(cancellationToken);
        }

        await using (var context = new PaymentsDbContext(options))
        {
            var price = Money.Create(100, "USD").Value;

            var payment = await context.Payments.SingleAsync(p => p.Quoted == price, cancellationToken);

            Assert.Equal(price, payment.Quoted);
        }
    }
}
