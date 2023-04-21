namespace SievePackage;
public interface IShoeRetrievalService
{
    public IQueryable<Shoe> GetShoes();
}

public class ShoeRetrievalService : IShoeRetrievalService
{
    public IQueryable<Shoe> GetShoes()
    {
        return new List<Shoe>
        {
            new()
            {
                Name = "Pegasus 39",
                Brand = "Nike",
                Price = 119.99M,
                Category = "Running",
                Rating = 4.5M
            },
            new()
            {
                Name = "Pegasus Trail 3",
                Brand = "Nike",
                Price = 129.99M,
                Category = "Trail",
                Rating = 3.8M
            },
            new()
            {
                Name = "Ride 15",
                Brand = "Saucony",
                Price = 119.99M,
                Category = "Neutral",
                Rating = 4.9M
            }
        }.AsQueryable();
    }
}
