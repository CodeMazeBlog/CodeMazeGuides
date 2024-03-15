using ShoeApi.Models;

namespace ShoeApi.Repositories;
public interface IShoeRepository
{
    List<Shoe> GetShoes();

    bool DeleteShoe(int id);
}
