namespace Tests
{
    public class FuncDelegateUnitTest
    {
        [Fact]
        public void SquareHappyPath()
        {
            // arrange
            var input = 5;
            var expected = 25;

            // act
            var actual = FuncDelegate.Program.square(input);

            // assert

            Assert.Equal(expected, actual);

        }

        [Fact]
        public void MakeSureMainMethodWorks()
        {
            FuncDelegate.Program.Main(new string[0]);
        }
    }
}