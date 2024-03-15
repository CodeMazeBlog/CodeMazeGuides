namespace Tests;
public class LiveTests
{
    [Fact]
    public async Task WhenGetById_ThenRepositoryRetunsSingleEntity()
    {
        //Arrange
        var entityId = 1;
        var expectedEntity = new { Id = entityId, Make = "Mercedes Benz'", Model = "GLC", Color = "Black", Year = 2014 };
        var mockConfigurationWrapper = new Mock<IConfigurationWrapper>();
        mockConfigurationWrapper.Setup(c => c.GetConnectionString("SqlConnection")).Returns("Server=(localdb)\\MSSQLLocalDB;Initial Catalog=Entities;Trusted_Connection=True;");
        var dapperContext = new DapperContext(mockConfigurationWrapper.Object);
        var mockLogger = new Mock<ILogger<Repository>>();
        var repsository = new Repository(mockLogger.Object, dapperContext);

        //Act
        var result = await repsository.GetById(1);

        //Assert
        Assert.NotNull(result);
        Assert.Equal(expectedEntity.Id, result.Id);
    }
}
