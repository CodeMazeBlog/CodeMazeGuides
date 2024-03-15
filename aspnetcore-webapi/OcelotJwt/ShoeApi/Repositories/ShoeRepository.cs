using ShoeApi.Models;

namespace ShoeApi.Repositories;
public class ShoeRepository : IShoeRepository
{

    private static List<Shoe> _shoes = new()
    {
        new()
        {
            Id = 1,
            Name = "Pegasus 39",
            Brand = "Nike",
            Price = 119.99M
        },
        new()
        {
            Id = 2,
            Name = "Vaporfly",
            Brand = "Nike",
            Price = 229.99M
        },
        new()
        {
            Id = 3,
            Name = "Ride 15",
            Brand = "Saucony",
            Price = 119.99M
        }
    };

    public List<Shoe> GetShoes() => _shoes;

    public bool DeleteShoe(int id)
    {
        var shoe = _shoes.FirstOrDefault(s => s.Id == id);

        if (shoe is not null)
        {
            return _shoes.Remove(shoe);
        }

        return false;
    }
}
