using CollectionsInCSharp;
using System.Collections;
using System.Collections.Concurrent;

namespace Tests
{
    public class ConcurrentCollectionsTest
    {
        [Fact]
        public void GivenEmptyConcurrentDictionary_WhenAddingToConcurrentDictionary_ThenReturnsPopulatedConcurrentDictionary()
        {
            var result = ConcurrentCollections.CreateConcurrentNumbersDictionary();

            Assert.IsType<ConcurrentDictionary<int, string>>(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void GivenConcurrentDictionary_WhenReadingFromConcurrentDictionary_ThenReturnsAString()
        {
            var dict = ConcurrentCollections.CreateConcurrentNumbersDictionary();
            var result = ConcurrentCollections.ReadFromConcurrentNumbersDictionary(dict);

            Assert.IsType<string>(result);
        }

        [Fact]
        public void GivenEmptyConcurrentQueue_WhenAddingToConcurrentQueue_ThenReturnsPopulatedConcurrentQueue()
        {
            var result = ConcurrentCollections.CreateConcurrentNumbersQueue();

            Assert.IsType<ConcurrentQueue<int>>(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void GivenConcurrentQueue_WhenReadingFromConcurrentQueue_ThenReturnsAnIntegerOrNull()
        {
            var queue = ConcurrentCollections.CreateConcurrentNumbersQueue();
            var result = ConcurrentCollections.ReadFromConcurrentNumbersQueue(queue);

            Assert.IsType<ArrayList>(result);
        }

        [Fact]
        public void GivenEmptyConcurrentstack_WhenAddingToConcurrentstack_ThenReturnsPopulatedConcurrentstack()
        {
            var result = ConcurrentCollections.CreateConcurrentOperationStack();

            Assert.IsType<ConcurrentStack<string>>(result);
        }

        [Fact]
        public void GivenConcurrentStack_WhenReadingFromConcurrentStack_ThenReturnsAStringOrNull()
        {
            var stack = ConcurrentCollections.CreateConcurrentOperationStack();
            var result = ConcurrentCollections.ReadFromConcurrentOperationStack(stack);

            Assert.IsType<string?>(result);
        }
    }
}