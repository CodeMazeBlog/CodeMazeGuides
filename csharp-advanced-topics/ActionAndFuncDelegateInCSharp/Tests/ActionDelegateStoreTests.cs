using System;
using ActionAndFuncDelegateInCSharp;
using Xunit;

namespace Tests
{
    public class ActionDelegateStoreTests
    {
        private readonly ActionDelegateStore _store;

        public ActionDelegateStoreTests() => _store = new ActionDelegateStore();

        [Theory]
        [InlineData("ReverseString")]
        [InlineData("AppendUnderScore")]
        public void ActionDelegateStoreIndexer_ReturnsActionDelegate(string param)
        {
            var actiondeleggate = _store[param];
            Assert.IsType<Action<string>>(actiondeleggate);
        }

        [Theory]
        [InlineData("RandonText")]
        [InlineData("RandomTextTwo")]
        public void ActionDelegateStoreIndexerWithWrongMethodName_ReturnsNull(string param)
        {
            var actiondeleggate = _store[param];
            Assert.Null(actiondeleggate);           
        }

        [Fact]
        public void ReverseString_whenExecuted_storesTheInputReversed()
        {
            _store["ReverseString"]("boy");
            Assert.Equal("yob", _store.ReversedString);
        }
        
        [Fact]
        public void AppendUnderScore_whenExecuted_storesTheInputWithUnderScore()
        {
            _store["AppendUnderScore"]("boy");
            Assert.Equal("boy_", _store.UnderScoreString);
        }
    }
}
