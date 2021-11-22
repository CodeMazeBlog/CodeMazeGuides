using System;
using ActionAndFuncDelegateInCSharp;
using Xunit;

namespace Tests
{
    public class FuncDelegateStoreTests
    {
        private readonly FuncDelegateStore _store;

        public FuncDelegateStoreTests() => _store = new FuncDelegateStore();


        [Theory]
        [InlineData("CheckStringLength")]
        [InlineData("MultiplyStringLength")]
        public void FuncDelegateStoreIndexer_ReturnsFuncDelegate(string param)
        {
            var funcdelegate = _store[param];
            Assert.IsType<Func<string, int>>(funcdelegate);
        }

        [Theory]
        [InlineData("RandonText")]
        [InlineData("RandomTextTwo")]
        public void FuncDelegateStoreIndexerWithWrongMethodName_ReturnsNull(string param)
        {
            var actiondeleggate = _store[param];
            Assert.Null(actiondeleggate);
        }

        [Fact]
        public void CheckStringLength_whenExecuted_returnsStringLength()
        {
            var length = _store["CheckStringLength"]("boy");
            Assert.Equal(3, length);
        }

        [Fact]
        public void MultiplyStringLength_whenExecuted_returnStringLengthMultipliedByTwo ()
        {
            var multipliedLength = _store["MultiplyStringLength"]("boy");
            Assert.Equal(6, multipliedLength);
        }
    }
}
