using UpcastingAndDowncasting;

namespace Tests
{
    public class Test
    {
        [Fact]
        public void WhenSnakeMakeSound_ThenHiss()
        {
            var snake = new Snake();

            Assert.Equal("Hiss", snake.MakeSound());
        }

        [Fact]
        public void WhenOwlMakeSound_ThenHoot()
        {
            var owl = new Owl();

            Assert.Equal("Hoot", owl.MakeSound());
        }
    }
}