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
        [DataRow("woof", "meow", "moo", "baa")]
        [DataRow("play with me", "do not look at me", "do not touch those", "i am too hot")]
        public void GivenDIAnimalSounds_ThenAnimalSoundsInjected(string dogSound, string catSound, string cowSound, string sheepSound)
        {
            using (var mock = AutoMock.GetLoose(cfg => cfg.RegisterInstance(sheepSound)))
            {
                mock.Mock<IDogSoundService>().Setup(x => x.GetSound()).Returns(dogSound);
                mock.Mock<IConfiguration>().Setup(x => x["CatSound"]).Returns(catSound);
                mock.Mock<IOptions<CowOptions>>().Setup(x => x.Value).Returns(new CowOptions()
                {
                    CowSound = cowSound
                });

                var service = mock.Create<AnimalSoundService>();

                CollectionAssert.Contains(service.AnimalSounds, dogSound);
                CollectionAssert.Contains(service.AnimalSounds, catSound);
                CollectionAssert.Contains(service.AnimalSounds, cowSound);
                CollectionAssert.Contains(service.AnimalSounds, sheepSound);
            }
        }
    }
}