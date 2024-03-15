using VirtualAndAbstractMethodInCSharp;
using Xunit.Abstractions;

namespace Tests
{
    public class VirtualAndAbstractMethodUnitTest(ITestOutputHelper outputHelper)
    {
        private readonly TransportAgency _agency = new();
        private readonly ITestOutputHelper _output = outputHelper;

        [Fact]
        public void GivenValidInput_WhenAbstractMethodCalled_ThenNoError()
        {
            _output.WriteLine($"This test case validates the error-free execution of the Abstract method upon invocation with valid input value for distance: 1000");

            var mode = _agency.CreateTransportMode(TransportModeType.Car);

            var actualTravelTime = mode.GetTravelTime(1000);

            var expectedTravelTime = 16.666666666666668;

            Assert.StrictEqual(expectedTravelTime, actualTravelTime);
        }

        [Fact]
        public void GivenValidInput_WhenVirtualMethodCalled_ThenNoError()
        {
            _output.WriteLine($"This test case validates the error-free execution of the Virtual method upon invocation with valid input value for distance: 1000");

            var mode = _agency.CreateTransportMode(TransportModeType.Car);            
    
            double actualBaseFare = mode.CalculateBaseFare(1000);

            double expectedBaseFare = 502.5;       

            Assert.StrictEqual(expectedBaseFare, actualBaseFare);
        }

        [Theory]
        [InlineData(1000)]
        [InlineData(250)]
        [InlineData(501)]
        public void DistanceGreaterThan500_TrainVirtualMethod_Additional10PercDisc(int distance)
        {
            _output.WriteLine($"This test validates that the Train class applies a 10% discount for distances over 500 by overriding the base class's virtual method.\nFor distances under 500, it leverages the base class implementation for fare calculation.");

            double expectedBaseFare = distance <= 500 ? distance * 0.5 : distance * 0.5 * 0.9;

            var mode = _agency.CreateTransportMode(TransportModeType.Train);

            double actualBaseFare = mode.CalculateBaseFare(distance);

            Assert.StrictEqual(expectedBaseFare, actualBaseFare);
        }
    }
}