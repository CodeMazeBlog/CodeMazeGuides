using MongoDB.Bson;
using Xunit.Abstractions;

namespace Test
{
    public class ObjectIdServiceUnitTest
    {

        private readonly ITestOutputHelper output;

        public ObjectIdServiceUnitTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void WhenComparingObjectIds_ThenCreateValidObjectId()
        {
            //Arrange
            var firstId = ObjectId.GenerateNewId();

            var secondId = ObjectId.GenerateNewId();

            var expectedComparisonResult = -1;

            //Act
            int comparisonResult = firstId.CompareTo(secondId);

            bool areEqual = firstId.Equals(secondId);

            //Assert
            Assert.Equal(expectedComparisonResult, comparisonResult);

            Assert.False(areEqual);
        }

        [Fact]
        public void WhenUsingByteArray_ThenCreateValidObjectId()
        {
            //Arrange
            var byteArray = new byte[] { 0x5F, 0x4B, 0x76, 0x84, 0x87, 0x53, 0xED, 0x99, 0xFB, 0x1F, 0x18, 0xAC };

            //Act
            var objectId = new ObjectId(byteArray);

            //Assert
            Assert.IsAssignableFrom<ObjectId>(objectId);           
        }

        [Fact]
        public void WhenUsingHexString_ThenCreateValidObjectId()
        {
            //Arrange
            var hexString = "5F4B76848753ED99FB1F18AC";

            //Act
            var objectId = new ObjectId(hexString);

            //Assert
            Assert.IsAssignableFrom<ObjectId>(objectId);
        }

        [Fact]
        public void WhenGenerateNewId_ThenCreateValidObjectId()
        {
            //Arrange

            var dateTime = new DateTime(2023, 10, 10);            

            var intTimeStamp = 20;

            //Act
            var objectId = ObjectId.GenerateNewId();

            var objectIdTwo = ObjectId.GenerateNewId(dateTime);

            var objectIdThree = ObjectId.GenerateNewId(intTimeStamp);

            //Assert
            Assert.IsAssignableFrom<ObjectId>(objectId);

            Assert.IsAssignableFrom<ObjectId>(objectIdTwo);

            Assert.IsAssignableFrom<ObjectId>(objectIdThree);
        }

        [Fact]
        public void WhenUsingParsing_ThenCreateValidObjectId()
        {
            //Arrange
            var hexString = "5F4B76848753ED99FB1F18AC";

            //Act
            var objectIdFromParsedString = ObjectId.Parse(hexString);

            bool canParse = ObjectId.TryParse(hexString, out ObjectId objectIdFromTryParse);

            //Assert
            Assert.IsAssignableFrom<ObjectId>(objectIdFromTryParse);

            Assert.IsAssignableFrom<ObjectId>(objectIdFromParsedString);

            Assert.True(canParse);
        }
    }
}
