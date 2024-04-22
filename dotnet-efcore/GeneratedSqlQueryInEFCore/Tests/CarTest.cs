namespace Tests;

public class CarTest
{
    [Fact]
    public void GivenCarsIsNotEmpty_WhenGetCarsMethodIsCalled_ThenReturnListOfCars()
    {
        var apiContextMock = new Mock<ApiContext>();
        apiContextMock.Setup(x => x.Cars).ReturnsDbSet(GetCars());

        var carRepositoryMock = new CarRepository(apiContextMock.Object);

        var cars = carRepositoryMock.GetCars();

        Assert.NotNull(cars);

        Assert.Equal(2, cars.Count());
    }

    private IEnumerable<Car> GetCars()
    {
        return new List<Car>()
        {
           new Car
           {
                Id = 1,
                Brand = "BMW",
                Model = "1 Series",
                Year = 2012,
                Name = "118d HatchBack"
            },
            new Car
            {
                Id = 2,
                Brand = "BMW",
                Model = "1 Series",
                Year = 2013,
                Name = "118d M Sport 3 Door HatchBack"
            }
        };
    }
}