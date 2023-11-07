namespace Tests;

public class UnitTest
{
    [Fact]
    public async Task WhenGetById_ThenServiceReturnsSingleEntity()
    {
        //Arrange
        var mockRepository = new Mock<IRepository>();
        var service = new Service(mockRepository.Object);
        var entityId = 1;
        var expectedEntity = new { Id = entityId, Make = "Mazda", Model = "MD-233H", Color = "Japan", Year = 2025 };
        mockRepository.Setup(repository => repository.GetById(entityId)).ReturnsAsync(expectedEntity);

        //Act
        var result = await service.GetById(entityId);

        //Assert
        Assert.Equal(expectedEntity, result);
    }
}