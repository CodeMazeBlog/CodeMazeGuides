using ActionAndFuncInCsharp.Implementations;
using ActionAndFuncInCsharp.Implementations.Vehicles;
using ActionAndFuncInCsharp.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Tests
{
    [TestClass]
    public class ParkingManagementUnitTests
    {
        [TestMethod]
        public void WhenGettingBarDrawingPassingZeroPointThree_ThenGetThreeOfTenBarPins()
        {
            //Arrange
            var progressManager = new ProgressManager();

            //Act           
            var actual = progressManager.GetProgressBarDrawing(0.3);

            //Assert
            const string expected = "|||";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void WhenUpdatingProgress_ThenProgressIsCorrectlyUpdated()
        {
            //Arrange
            var progressManager = new ProgressManager();

            //Act
            progressManager
                .UpdateProgress(new Progress("The Motorcycle is Parked.", 0.5, "|||||"));

            //Assert
            const string expectedCurrentMessage = "The Motorcycle is Parked.";
            const string expectedCurrentBarDrawing = "|||||";
            const string expectedCurrentProgressValue = "50 %";
            Assert.AreEqual(expectedCurrentMessage, actual: progressManager.CurrentMessage);
            Assert.AreEqual(expectedCurrentBarDrawing, actual: progressManager.CurrentBarDrawing);
            Assert.AreEqual(expectedCurrentProgressValue, actual: progressManager.CurrentProgressValue);
        }

        [TestMethod]
        public void WhenParkingACar_ThenTheCarIsParked()
        {
            //Arrange           
            var car = new Car();

            ////Act
            var actual = car.Park();

            //Assert
            const string expected = "The Car is parked.";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void WhenParkingABusInParkingLot_ThenTheBusIsParked()
        {
            //Arrange                        
            const string isParkedMessage = "The Bus is parked.";            
            var mockedBus = new Mock<IVehicle>();

            mockedBus.Setup(x => x.Park()).Returns(isParkedMessage);

            var mockedVehicles = new List<IVehicle>() { mockedBus.Object };
            var parkingLot = new ParkingLot();

            //Act
            var actual = parkingLot.Park(mockedBus.Object);

            //Assert
            const string expected = "The Bus is parked.";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void WhenManagingTheParkingOfAListOfVehiclesInParkingLot_ThenNoExceptionIsThrow()
        {
            //Arrange                                    
            var mockedTruck = new Mock<IVehicle>();
            mockedTruck.Setup(x => x.Park());

            var mockedVehicles = new List<IVehicle>() { mockedTruck.Object };
            var mockedParkingLot = new Mock<IParkingLot>();
            mockedParkingLot.Setup(x => x.Park(It.IsAny<IVehicle>()));

            var mockedProgressManager = new Mock<IProgressManager>();
            mockedProgressManager.Setup(x => x.GetProgressBarDrawing(It.IsAny<double>()));
            mockedProgressManager.Setup(x => x.UpdateProgress(It.IsAny<IProgress>()));
            mockedProgressManager.Setup(x => x.CurrentMessage);
            mockedProgressManager.Setup(x => x.CurrentBarDrawing);
            mockedProgressManager.Setup(x => x.CurrentProgressValue);

            var parkingManager = new ParkingManager();

            //Act
            Exception? actualException = null;

            try
            {
                parkingManager.ParkAllVehicles(mockedParkingLot.Object, mockedVehicles,
                mockedProgressManager.Object.GetProgressBarDrawing,
                mockedProgressManager.Object.UpdateProgress);
            }
            catch (Exception exception)
            {
                actualException = exception;
            }

            //Assert                       
            Assert.IsNull(actualException);
        }
    }
}
