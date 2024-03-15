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
            var cargoType = Plane.Cargo;
            var passengerType = Plane.Passenger;
            var militaryType = Plane.Military;

            // Act
            var cargoPlane = Plane.Create(cargoType);
            var passengerPlane = Plane.Create(passengerType);
            var militaryPlane = Plane.Create(militaryType);

            // Assert
            Assert.IsInstanceOfType(cargoPlane, typeof(CargoPlane));
            Assert.IsInstanceOfType(passengerPlane, typeof(PassengerPlane));
            Assert.IsInstanceOfType(militaryPlane, typeof(MilitaryPlane));
        }

        [TestMethod]
        public void WhenGetCapacityInvoked_ThenCorrectValueIsReturned()
        {
            // Arrange
            var cargoPlane = Plane.Create(Plane.Cargo);

            // Act
            var capacity = cargoPlane.GetCapacity();

            // Assert
            Assert.AreEqual(10000, capacity);
        }
    }
}
