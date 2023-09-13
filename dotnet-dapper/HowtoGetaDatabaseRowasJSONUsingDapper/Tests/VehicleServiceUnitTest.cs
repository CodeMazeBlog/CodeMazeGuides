using HowtoGetaDatabaseRowasJSONUsingDapper.Contracts;
using HowtoGetaDatabaseRowasJSONUsingDapper.Entities;
using HowtoGetaDatabaseRowasJSONUsingDapper.Services;
using Moq;

namespace Tests
{
    public class VehicleServiceUnitTest
    {
        [Fact]
        public async Task WhenGetVehicle_ThenReturnSingleVehicle()
        {
            //Arrange
            var mockRepository = new Mock<IVehicleRepository>();
            var vehicleService = new VehicleService(mockRepository.Object);
            var companyId = 1;
            var expectedVehicle = new Vehicle { Id = companyId, Name = "Mazda", City = "Tokyo", Country = "Japan" };
            mockRepository.Setup(repository => repository.GetVehicle(companyId)).ReturnsAsync(expectedVehicle);

            //Act
            var result = await vehicleService.GetVehicle(companyId);

            //Assert
            Assert.Equal(expectedVehicle, result);
        }
    }
}