using EarlyAndLateBinding;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace AnimalTests
{
    [TestClass]
    public class AnimalTests
    {
        private Animal? animal;

        [TestInitialize]
        public void Setup()
        {
            animal = new Animal();
        }

        [TestMethod]
        public void GivenAnimalInstance_WhenSpeakCalled_ThenOutputIsAnimalSound()
        {
            var result = animal?.Speak();

            Assert.AreEqual("The animal makes a sound.", result);
        }

        [TestMethod]
        public void GivenDynamicAnimalInstance_WhenSpeakCalled_ThenOutputIsAnimalSound()
        {
            dynamic dynamicAnimal = new Animal();

            var result = dynamicAnimal.Speak();

            Assert.AreEqual("The animal makes a sound.", result);
        }

        [TestMethod]
        public void GivenAnimalTypeUsingReflection_WhenSpeakInvoked_ThenOutputIsAnimalSound()
        {
            Type animalType = typeof(Animal);
            object objectAnimal = Activator.CreateInstance(animalType)!;
            MethodInfo speakMethod = animalType.GetMethod("Speak")!;

            var result = speakMethod?.Invoke(objectAnimal, null);

            Assert.AreEqual("The animal makes a sound.", result);
        }
    }
}
