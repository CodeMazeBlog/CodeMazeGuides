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
            _collection.ArrayList.Add("2"); // Convert.TInt32()  will convert
                                            // this to integer equivalent "2" to 2
            _collection.ArrayList.Add("Three"); // Convert.ToInt32() fails
                                                // to convert this to integer equivalent
                                                // and throw FormatException


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