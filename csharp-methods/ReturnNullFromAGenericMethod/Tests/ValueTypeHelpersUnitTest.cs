using ReturnNullFromAGenericMethod;

namespace Tests
{
    public class ValueTypeHelpersUnitTest
    {
        [Fact]
        public void GivenNullableValueType_WhenNullReturned_ThenThrowInvalidOperationException()
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5 };
            var number = ValueTypeHelpers.FindItem(numbers, 6);

            Assert.Null(number);
            Assert.Throws<InvalidOperationException>(() => number.Value);
        }
    }
}
