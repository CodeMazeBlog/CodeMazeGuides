using SnapshotTestingWithVerify;

namespace Tests;

public class VerifyVehicleTests
{
    [Fact]
    public Task WhenGetVehicleIsCalled_ThenReturnsTheCorrectObject()
    {
        var vehicle = VehicleFactory.GetVehicle();
        return Verify(vehicle);
    }
}