using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using ValueObjects.Entities;
using ValueObjects.Persistence;
using ValueObjects.TypeSafety;
using ValueObjects.ValueObjects;

var refused = Money.Create(-5m, "USD");

Console.WriteLine(refused.IsSuccess);
Console.WriteLine(refused.Error);

var originCountry = new Country("US", "United States of America");
var originStation = new Station("JFK", "John F. Kennedy International Airport");
var destinationCountry = new Country("CA", "Canada");
var destinationStation = new Station("YVR", "Vancouver International Airport");

Console.WriteLine(new TicketPriceProvider().GetTicketPrice(originCountry, originStation, destinationCountry, destinationStation));

var hundredUsd = Money.Create(100m, "USD").Value;
var typedInLowerCase = Money.Create(100m, "usd").Value;
var hundredEur = Money.Create(100m, "EUR").Value;

Console.WriteLine(hundredUsd == typedInLowerCase);
Console.WriteLine(hundredUsd == hundredEur);
Console.WriteLine(new Payment(hundredUsd) == new Payment(hundredUsd));

await using var connection = new SqliteConnection("Data Source=:memory:");
await connection.OpenAsync();

var options = new DbContextOptionsBuilder<PaymentsDbContext>()
    .UseSqlite(connection)
    .Options;

await using (var context = new PaymentsDbContext(options))
{
    await context.Database.EnsureCreatedAsync();
    Console.WriteLine(context.Database.GenerateCreateScript().TrimEnd());

    context.Payments.Add(new Payment(typedInLowerCase));
    await context.SaveChangesAsync();
}

await using (var context = new PaymentsDbContext(options))
{
    var price = Money.Create(100m, "USD").Value;
    var query = context.Payments.Where(p => p.Quoted == price);

    Console.WriteLine(query.ToQueryString());

    var payment = await query.SingleAsync();

    Console.WriteLine(payment.Quoted);
    Console.WriteLine(payment.Quoted == hundredUsd);
}

Station[] stops = [new("JFK", "John F. Kennedy International Airport"), new("YVR", "Vancouver International Airport")];
Station[] sameStops = [new("JFK", "John F. Kennedy International Airport"), new("YVR", "Vancouver International Airport")];

Console.WriteLine(new Route(stops) == new Route(sameStops));
