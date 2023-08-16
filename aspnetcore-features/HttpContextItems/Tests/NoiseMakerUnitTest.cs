using NoiseMakerNames;

namespace Tests
{
    public class NoiseMakerUnitTest
    {
        [Fact]
        public void WhenAddNoiseMakerIsCalled_ThenNewNoiseMakerIsAddedToTheList()
        {
            //arrange
            var namesOfNoiseMakers = new NamesOfNoiseMakers();

            var noiseMaker = new NoiseMaker()
            {
                Name = "Mira",
                Severity = 2,
                FirstAppearance = true
            };

            //act
            namesOfNoiseMakers.AddNoiseMaker(noiseMaker);
            var noiseMakerList = namesOfNoiseMakers.GetNoiseMakers();

            //assert
            Assert.NotNull(noiseMakerList);
            Assert.Contains(noiseMaker, noiseMakerList);
        }
    }
}
