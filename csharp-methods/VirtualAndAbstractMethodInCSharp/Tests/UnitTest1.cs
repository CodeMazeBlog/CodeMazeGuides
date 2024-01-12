using VirtualAndAbstractMethodInCSharp;

namespace Tests
{
    public class UnitTest1
    {
        private readonly TransportAgency agency;

        public UnitTest1()
        {
            this.agency = new TransportAgency();
        }

        [Fact]
        public void GivenValidInput_WhenAbstractMethodCalled_NoError()
        {
            TransportMode mode = agency.CreateTransportMode(TransportModeType.Car);

            var actualTravelTime = mode.GetTravelTime(1000);

            Assert.StrictEqual(16.666666666666668, actualTravelTime);
        }

        [Fact]
        public void GivenValidInput_WhenVirtualMethodCalled_NoError()
        {
            TransportMode mode = agency.CreateTransportMode(TransportModeType.Car);

            var actualFare = mode.CalculateBaseFare(1000);

            Assert.StrictEqual(502.5, actualFare);
        }

        [Theory]
        [InlineData(1000)]
        [InlineData(250)]
        [InlineData(501)]
        public void DistanceGreaterThan500_TrainVirtualMethod_Additional10PercDisc(int distance)
        {
            double expectedBaseFare = distance <= 500 ? distance * 0.5 : distance * 0.5 * 0.9;

            TransportMode mode = agency.CreateTransportMode(TransportModeType.Train);

            double actualFare = mode.CalculateBaseFare(distance);

            Assert.StrictEqual(expectedBaseFare, actualFare);
        }
    }
}