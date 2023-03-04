using RefactoringObjectOrientationAbusers.SwitchStatements.Correct;

namespace Tests
{
    [TestClass]
    public class PlaneUnitTests
    {
        [TestMethod]
        public void WhenCreatingNewPlane_ThenInstanceOfCorrectTypeIsReturned()
        {
            // Arrange
            int cargoType = Plane.Cargo;
            int passengerType = Plane.Passenger;
            int militaryType = Plane.Military;

            // Act
            Plane cargoPlane = Plane.Create(cargoType);
            Plane passengerPlane = Plane.Create(passengerType);
            Plane militaryPlane = Plane.Create(militaryType);

            // Assert
            Assert.IsInstanceOfType(cargoPlane, typeof(CargoPlane));
            Assert.IsInstanceOfType(passengerPlane, typeof(PassengerPlane));
            Assert.IsInstanceOfType(militaryPlane, typeof(MilitaryPlane));
        }

        [TestMethod]
        public void WhenGetCapacityInvoked_ThenCorrectValueIsReturned()
        {
            // Arrange
            Plane cargoPlane = Plane.Create(Plane.Cargo);

            // Act
            double capacity = cargoPlane.GetCapacity();

            // Assert
            Assert.AreEqual(10000, capacity);
        }
    }
}
