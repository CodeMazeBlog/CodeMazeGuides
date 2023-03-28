using EmptyStringArrayFactory;
namespace Tests
{
    public class ArrayUnitTest
    {
        private readonly int _expectedSize = 0;

        [Fact]
        public void WhenCreateEmptyArrayExample1IsCalled_ThenReturnAnEmptyStringArray()
        {
            var actual = ArrayFactory.CreateEmptyArrayExample1();
            Assert.Equal(_expectedSize, actual.Length);
        }

        [Fact]
        public void WhenCreateEmptyArrayExample2IsCalled_ThenReturnAnEmptyStringArray()
        {
            var actual = ArrayFactory.CreateEmptyArrayExample2();
            Assert.Equal(_expectedSize, actual.Length);
        }

        [Fact]
        public void WhenCreateEmptyArrayExample3IsCalled_ThenReturnAnEmptyStringArray()
        {
            var actual = ArrayFactory.CreateEmptyArrayExample3();
            Assert.Equal(_expectedSize, actual.Length);
        }

        [Fact]
        public void WhenCreateEmptyArrayExample4IsCalled_ThenReturnAnEmptyStringArray()
        {
            var actual = ArrayFactory.CreateEmptyArrayExample4();
            Assert.Equal(_expectedSize, actual.Length);
        }

        [Fact]
        public void WhenCreateEmptyArrayExample5IsCalled_ThenReturnAnEmptyStringArray()
        {
            var actual = ArrayFactory.CreateEmptyArrayExample5();
            Assert.Equal(_expectedSize, actual.Length);
        }

        [Fact]
        public void WhenCreateEmptyArrayExample6IsCalled_ThenReturnAnEmptyStringArray()
        {
            var actual = ArrayFactory.CreateEmptyArrayExample6();
            Assert.Equal(_expectedSize, actual.Length);
        }

        [Fact]
        public void WhenCreateEmptyArrayExample7IsCalled_ThenReturnAnEmptyStringArray()
        {
            var actual = ArrayFactory.CreateEmptyArrayExample7();
            Assert.Equal(_expectedSize, actual.Length);
        }
    }
}