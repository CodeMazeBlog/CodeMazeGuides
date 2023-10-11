using HowtoGetaDatabaseRowasJSONUsingDapper.Contracts;
using HowtoGetaDatabaseRowasJSONUsingDapper.Services;
using Moq;

namespace Tests
{
    public class ServiceUnitTest
    {
        [Fact]
        public async Task WhenGetById_ThenReturnSingleEntity()
        {
            //Arrange
            var mockRepository = new Mock<IRepository>();
            var vehicleService = new Service(mockRepository.Object);
            var companyId = 1;
            var expectedVehicle = new { Id = companyId, Make = "Mazda", Model = "MD-233H",Color = "Japan", Year = 2025 };
            mockRepository.Setup(repository => repository.GetById(companyId)).ReturnsAsync(expectedVehicle);

            //Act
            var result = await vehicleService.GetById(companyId);

            //Assert
            Assert.Equal(expectedVehicle, result);
        }
    }
}