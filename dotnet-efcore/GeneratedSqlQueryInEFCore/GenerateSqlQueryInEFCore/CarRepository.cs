using Microsoft.EntityFrameworkCore;

namespace GenerateSqlQueryInEFCore;

public class CarRepository(ApiContext context) : ICarRepository
{
    public List<Car> GetCars()
    {
        var cars = context.Cars;
        Console.WriteLine(cars.ToQueryString());

        return cars.ToList();
    }
}