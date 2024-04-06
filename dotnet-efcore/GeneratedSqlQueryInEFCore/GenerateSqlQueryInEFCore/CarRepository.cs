using Microsoft.EntityFrameworkCore;

namespace GenerateSqlQueryInEFCore;

public class CarRepository(ApiContext context) : ICarRepository
{
    readonly ApiContext _context = context;

    public List<Car> GetCars()
    {
        var cars = _context.Cars;
        Console.WriteLine(cars.ToQueryString());

        return cars.ToList();
    }
}