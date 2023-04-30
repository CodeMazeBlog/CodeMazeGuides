using ShoeApi.Models;

namespace ShoeApi.Repositories;
public interface IShoeRepository
{
    List<Shoe> GetShoes();
    Shoe? GetShoe(int id);

    bool DeleteShoe(int id);
}
