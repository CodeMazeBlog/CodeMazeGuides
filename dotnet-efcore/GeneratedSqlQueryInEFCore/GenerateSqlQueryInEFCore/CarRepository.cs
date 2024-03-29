using Microsoft.EntityFrameworkCore;

namespace GenerateSqlQueryInEFCore;

public class CarRepository : ICarRepository
{
    readonly ApiContext _context;

    public CarRepository(ApiContext context)
    {
        _context = context;
    }

    public List<Car> GetCars()
    {
        var cars = _context.Cars;
        Console.WriteLine(cars.ToQueryString());

        return cars.ToList();
    }
}