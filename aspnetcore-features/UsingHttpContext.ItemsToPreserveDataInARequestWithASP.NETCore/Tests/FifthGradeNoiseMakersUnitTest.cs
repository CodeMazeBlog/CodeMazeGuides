using FifthGradeNoiseMakers;

namespace Tests
{
    public class FifthGradeNoiseMakersUnitTest
    {
        [Fact]
        public void WhenAddNoiseMakerIsCalled_ThenNewNoiseMakerIsAddedToTheList()
        {
            //arrange
            NamesOfNoiseMakers namesOfNoiseMakers = new();
            NoiseMaker noiseMaker = new()
            {
                Name = "Mira",
                Severity = 2,
                FirstAppearance = true
            };

            //act
            namesOfNoiseMakers.AddNoiseMaker(noiseMaker);
            List<NoiseMaker> noiseMakerList = namesOfNoiseMakers.ViewNoiseMakers();


            //assert
            Assert.NotNull(noiseMakerList);
            Assert.Contains(noiseMaker, noiseMakerList);

        }
    }
}