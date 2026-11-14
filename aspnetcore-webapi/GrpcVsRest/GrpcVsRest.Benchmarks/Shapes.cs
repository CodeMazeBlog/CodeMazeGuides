using System.Text.Json;
using Google.Protobuf;
using GrpcVsRest.Server;

namespace GrpcVsRest.Benchmarks;

public record ReadingDto(int SensorId, long Timestamp, double Temperature, double Humidity, double Pressure);

public record ReviewDto(int Id, int ProductId, string Author, string Text);

public record Shape(string Name, object Dto, IMessage Message);

public static class Shapes
{
    public static readonly JsonSerializerOptions JsonOptions = new(JsonSerializerDefaults.Web);

    // Review text is built from random words, so the reviews differ the way real ones do
    // and gzip cannot cheat by finding the same sentence a hundred times.
    private static readonly string[] Words =
        ("the a and it works well after two days weeks months of daily use build quality cable desk " +
         "keys feel light bright status small large box arrived early late price good great fine poor " +
         "would buy again office home colleague upgrade replace battery charge fast slow screen sound " +
         "clear loud quiet setup easy hard driver update windows linux mac laptop monitor port plug " +
         "stand hub mouse keyboard webcam picture sharp blurry color warm cold metal plastic heavy " +
         "stable wobbly support answered quickly refund return shipping packaging damaged perfect " +
         "but not very really quite still never always sometimes only also too much more less than " +
         "my our their for with without on in at from to by under over before during because so")
        .Split(' ');

    private static string ReviewText(Random random, int words) =>
        string.Join(' ', Enumerable.Range(0, words).Select(_ => Words[random.Next(Words.Length)]));

    public static (List<ProductDto> Dto, ProductList Message) Catalog()
    {
        var dto = new ProductStore().All.ToList();
        var message = new ProductList();
        message.Products.AddRange(dto.Select(p => new Product
        {
            Id = p.Id, Name = p.Name, Category = p.Category, Price = p.Price, Stock = p.Stock
        }));

        return (dto, message);
    }

    public static (List<ReadingDto> Dto, ReadingList Message) Readings()
    {
        var random = new Random(42);
        var start = new DateTimeOffset(2026, 10, 1, 8, 0, 0, TimeSpan.Zero).ToUnixTimeMilliseconds();
        var dto = Enumerable.Range(0, 100)
            .Select(i => new ReadingDto(
                SensorId: 1 + i % 8,
                Timestamp: start + i * 1000L,
                Temperature: Math.Round(18 + random.NextDouble() * 8, 2),
                Humidity: Math.Round(35 + random.NextDouble() * 30, 2),
                Pressure: Math.Round(990 + random.NextDouble() * 40, 2)))
            .ToList();

        var message = new ReadingList();
        message.Readings.AddRange(dto.Select(r => new Reading
        {
            SensorId = r.SensorId, Timestamp = r.Timestamp, Temperature = r.Temperature,
            Humidity = r.Humidity, Pressure = r.Pressure
        }));

        return (dto, message);
    }

    public static (List<ReviewDto> Dto, ReviewList Message) Reviews()
    {
        var random = new Random(42);
        var dto = Enumerable.Range(1, 100)
            .Select(i => new ReviewDto(i, 1 + i % 20, $"Customer {i}", ReviewText(random, 30 + random.Next(30))))
            .ToList();

        var message = new ReviewList();
        message.Reviews.AddRange(dto.Select(r => new Review
        {
            Id = r.Id, ProductId = r.ProductId, Author = r.Author, Text = r.Text
        }));

        return (dto, message);
    }

    public static IEnumerable<Shape> All()
    {
        var catalog = Catalog();
        var readings = Readings();
        var reviews = Reviews();

        yield return new Shape("100 products (mixed)", catalog.Dto, catalog.Message);
        yield return new Shape("100 sensor readings (numbers)", readings.Dto, readings.Message);
        yield return new Shape("100 reviews (text)", reviews.Dto, reviews.Message);
    }
}
