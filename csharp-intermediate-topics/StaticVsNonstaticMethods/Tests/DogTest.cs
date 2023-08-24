using StaticVsNonstaticMethods;

namespace Tests
{
    [TestClass]
    public class DogTest
    {
        [TestMethod]
        public void GivenNoInput_WhenDogBark_ThenReturnShuldCallWriteLineOnce()
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            Dog.Bark();

            var output = stringWriter.ToString();
            var lines = output.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.AreEqual(1, lines.Length);
        }

        [TestMethod]
        [DataRow(-1)]
        [DataRow(-3)]
        [DataRow(-100)]
        public void GivenNegativeInput_WhenDogBark_ThenReturnShouldBeEmpty(int barkCount)
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            Dog.Bark(barkCount);

            var output = stringWriter.ToString();
            var lines = output.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.AreEqual(0, lines.Length);
        }


        [TestMethod]
        public void Given0Input_WhenDogBark_ThenReturnShouldBeEmpty()
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            Dog.Bark(0);

            var output = stringWriter.ToString();
            var lines = output.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.AreEqual(0, lines.Length);
        }

        [TestMethod]
        [DataRow(1, 1)]
        [DataRow(2, 2)]
        [DataRow(7, 7)]
        [DataRow(10, 10)]
        [DataRow(19, 19)]
        [DataRow(20, 20)]
        [DataRow(21, 20)]
        [DataRow(22, 20)]
        [DataRow(100, 20)]
        public void GivenPositiveInput_WhenDogBark_ThenReturnShouldTheSameButNotMoreThan20(int barkCount, int expectedBarkCount)
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            Dog.Bark(barkCount);

            var output = stringWriter.ToString();
            var lines = output.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.AreEqual(expectedBarkCount, lines.Length);
        }

    }
}
