using ArrayListVsList;
namespace Tests
{
    public class Test
    {
        Demo Demo { get; set; }
        public Test()
        {
            Demo = new();
        }

        [Fact]
        public void WhenValidObjectsAddedToArrayList_ThenSumSuccessful()
        {
            var expectedResult = 6;
            Demo.ArrayListDemo();
            Assert.Equal(expectedResult, Demo.Sum);
        }

        [Fact]
        public void WhenValidObjectsAddedToList_ThenSumSuccessful()
        {
            var expectedResult = 6;
            Demo.ListDemo();
            Assert.Equal(expectedResult, Demo.Sum);
        }

        [Fact]
        public void WhenInvalidObjectsAddedToArrayList_ThenSumFail()
        {
            var expectedResult = "FormatException";

            Demo.ArrayList.Add(1);
            Demo.ArrayList.Add("2");
            Demo.ArrayList.Add("Three");

            try
            {
                var actualResult = Demo.ArrayListSum(Demo.ArrayList);

            }
            catch (Exception ex)
            {
                Assert.Equal(expectedResult, ex.GetType().Name);
            }

        }
    }
}