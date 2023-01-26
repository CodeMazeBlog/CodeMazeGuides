using Autofac;
using Autofac.Extras.Moq;
using DependencyInjectionWithConstructorParameters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Tests
{
    [TestClass]
    public class DependencyInjectionWithConstructorParametersUnitTests
    {
        [TestMethod]
        public void GivenDIAnimalSounds_ThenAnimalSoundsInjected()
        {
            string dogSound = "woof",
                catSound = "meow",
                cowSound = "moo",
                sheepSound = "baa";

            using var mock = AutoMock.GetLoose(cfg => cfg.RegisterInstance(sheepSound));

            mock.Mock<IDogSoundService>().Setup(x => x.GetSound()).Returns(dogSound);
            mock.Mock<IConfiguration>().Setup(x => x["CatSound"]).Returns(catSound);
            mock.Mock<IOptions<CowOptions>>().Setup(x => x.Value).Returns(new CowOptions()
            {
                CowSound = cowSound
            });

            var service = mock.Create<AnimalSoundService>();

            var expectedAnimalSounds = new string[] { dogSound, catSound, cowSound, sheepSound };
            CollectionAssert.AreEquivalent(service.AnimalSounds, expectedAnimalSounds);
        }
    }
}