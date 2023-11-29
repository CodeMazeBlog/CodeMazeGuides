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

            DateTime dateTime = DateTime.Parse("2020-10-10");
            DateTime dateTime2 = DateTime.Parse("2020-11-10");
            DateTime dateTime3 = DateTime.Parse("2020-12-10");
            DateTime dateTime4 = DateTime.Parse("2020-10-12");
            DateTime dateTime5 = DateTime.Parse("2020-10-14");

            int intTimeStamp = 20;


            //Act
            var objectId = ObjectId.GenerateNewId();

            var objectIdTwo = ObjectId.GenerateNewId(dateTime);
            var objectId3 = ObjectId.GenerateNewId(dateTime2);
            var objectId4 = ObjectId.GenerateNewId(dateTime3);
            var objectId5 = ObjectId.GenerateNewId(dateTime4);
            var objectId6 = ObjectId.GenerateNewId(dateTime5);

            output.WriteLine(objectId.ToString());
            output.WriteLine(objectIdTwo.ToString());
            output.WriteLine(objectId3.ToString());
            output.WriteLine(objectId4.ToString());
            output.WriteLine(objectId5.ToString());
            output.WriteLine(objectId6.ToString());

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
