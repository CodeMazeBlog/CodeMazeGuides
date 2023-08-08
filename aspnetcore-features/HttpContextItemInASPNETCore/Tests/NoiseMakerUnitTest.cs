using NoiseMakerNames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class NoiseMakerUnitTest
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
