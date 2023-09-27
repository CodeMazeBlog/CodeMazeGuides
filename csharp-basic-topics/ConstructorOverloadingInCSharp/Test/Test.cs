using ConstructorOverloadingInCSharp;

namespace Test
{
    public class Test
    {
        [Fact]
        public void GivenDefaultConstructorWhenObjectInitializedThenPropertiesSet()
        {
            var animal = new Animal();

            string expected = "Hi! My name is Daffy, and I am a 85 years old duck.";
            string actual = animal.Speak();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GivenParametrizedConstructorWhenObjectInitializedThenPropertiesSet()
        {
            var animal = new Animal("Bugs", "bunny", 84);

            string expected = "Hi! My name is Bugs, and I am a 84 years old bunny.";
            string actual = animal.Speak();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GivenParametrizedConstructorWithDifferentTypesWhenObjectInitializedThenPropertiesSet()
        {
            var animal = new Animal("Sylvester", "cat", "83");

            string expected = "Hi! My name is Sylvester, and I am a 83 years old cat.";
            string actual = animal.Speak();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GivenParametrizedConstructorWithScrambledTypesWhenObjectInitializedThenPropertiesSet()
        {
            var animal = new Animal("mouse", 69, "Speedy");

            string expected = "Hi! My name is Speedy, and I am a 69 years old mouse.";
            string actual = animal.Speak();

            Assert.Equal(expected, actual);
        }
    }
}