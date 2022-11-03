using ReturnNullFromAGenericMethod;

namespace Tests
{
    public class ValueTypeHelpersTests
    {
        [Fact]
        public void GivenValueType_ShouldThrowInvalidOperationException_WhenNullReturned()
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5 };
            var number = ValueTypeHelpers.FindItem(numbers, 6);

            Assert.Null(number);
            Assert.Throws<InvalidOperationException>(() => number.Value);
        }
    }
}
