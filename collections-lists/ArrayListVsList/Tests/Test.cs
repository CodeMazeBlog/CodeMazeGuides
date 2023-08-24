using ArrayListVsList;
namespace Tests
{
    public class Test
    {
        private readonly Collection _collection;
        public Test()
        {
            _collection = new();
        }

        [Fact]
        public void WhenValidObjectsAddedToArrayList_ThenSumSuccessful()
        {
            var expectedResult = 6;

            _collection.ArrayListExample();

            Assert.Equal(expectedResult, _collection.Sum);
        }

        [Fact]
        public void WhenValidObjectsAddedToList_ThenSumSuccessful()
        {
            var expectedResult = 6;

            _collection.ListExample();

            Assert.Equal(expectedResult, _collection.Sum);
        }

        [Fact]
        public void WhenInvalidObjectsAddedToArrayList_ThenSumFail()
        {
            var expectedResult = "FormatException";

            _collection.ArrayList.Add(1);
            _collection.ArrayList.Add("2"); 
            _collection.ArrayList.Add("Three"); 

            try
            {
                var actualResult = _collection.GetSum(_collection.ArrayList);
            }
            catch (Exception ex)
            {
                Assert.Equal(expectedResult, ex.GetType().Name);
            }
        }
    }
}