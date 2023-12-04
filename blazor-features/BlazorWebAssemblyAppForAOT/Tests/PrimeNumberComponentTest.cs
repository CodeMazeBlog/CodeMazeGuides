using Microsoft.Extensions.DependencyInjection;

namespace Tests
{
    public class PrimeNumberComponentTest : TestContext
    {
        [Fact]
        public void GivenPrimeNumberComponentWhenInitializedReturnsListOfPrimeNumbers()
        {
            var mockPrimeNumberService = new Mock<IPrimeNumberService>();
            mockPrimeNumberService.Setup(service => service.GetPrimeNumbersAsync())
                .ReturnsAsync([2, 3, 5, 7, 11]);
            Services.AddSingleton(mockPrimeNumberService.Object);

            var cut = RenderComponent<PrimeNumber>();
            var timeout = TimeSpan.FromSeconds(5);
            cut.WaitForAssertion(() => Assert.NotNull(cut.Instance.PrimeNumbers), timeout);

            Assert.IsType<List<int>>(cut.Instance.PrimeNumbers);
            Assert.Equal([2, 3, 5, 7, 11], cut.Instance.PrimeNumbers);
        }
    }
}