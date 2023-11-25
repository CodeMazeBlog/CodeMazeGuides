namespace Tests
{
    public class PrimeNumberServiceTest
    {
        [Fact]
        public async Task GetPrimeNumbers_ReturnsListOfPrimeNumbers()
        {
            var primeNumberService = new PrimeNumberService();
            var primeNumbers = await primeNumberService.GetPrimeNumbersAsync();

            Assert.NotNull(primeNumbers);
            Assert.IsType<List<int>>(primeNumbers);

            Assert.Contains(2, primeNumbers);
            Assert.Contains(3, primeNumbers);
            Assert.Contains(5, primeNumbers);
            Assert.Contains(7, primeNumbers);
            Assert.Contains(11, primeNumbers);
            Assert.Contains(13, primeNumbers);
        }
    }
}