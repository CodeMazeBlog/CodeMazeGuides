using GlobalUsingDirectiveInCSharp.Model;
using Xunit;

namespace GlobalUsingDirectiveInCSharpUnitTest
{
    public class GlobalUsingDirectiveInCSharpUnitTest
    {
        [Fact]
        public void GivenAnEmptyMessage_WhenNewStoreIsCreated_ThenReturnMessage()
        {
            var message = string.Empty;

            var store = new Store { Name = "Fred and Sons Bakery", Owner = "Fred" };

            message = $"{store.Name} is owned by {store.Owner}";

            Assert.Equal("Fred and Sons Bakery is owned by Fred", message);
        }
    }
}