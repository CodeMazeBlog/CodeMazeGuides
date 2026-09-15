using ConcurrentBagInCSharp;
using System.Collections.Concurrent;

namespace Tests
{
    public class ConcurrentBagInCSharpTest
    {
        [Fact]
        public void GivenAnEmptyConcurrentBag_WhenCreatingAConcurrentBag_ThenReturnsConcurrentBag()
        {
            var result = ConcurrentBagDemo.CreateConcurrentBag();

            Assert.IsType<ConcurrentBag<int>>(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void GivenAnEmptyConcurrentBag_WhenAddingToAConcurrentBag_ThenReturnsAPopulatedConcurrentBag()
        {
            var result = ConcurrentBagDemo.CreateAndAddToConcurrentBagConcurrently();

            Assert.IsType<ConcurrentBag<int>>(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void GivenAConcurrentBag_WhenRemovingFromAConcurrentBag_ThenReturnsAList()
        {
            var bag = ConcurrentBagDemo.CreateAndAddToConcurrentBagConcurrently();
            var result = ConcurrentBagDemo.RemoveFromConcurrentBag(bag);

            Assert.IsType<List<int>>(result);
            Assert.Single(result);
        }

        [Fact]
        public void GivenAConcurrentBag_WhenRemovingFromAConcurrentBagConcurrently_ThenReturnsAList()
        {
            var bag = ConcurrentBagDemo.CreateAndAddToConcurrentBagConcurrently();
            var result = ConcurrentBagDemo.RemoveFromConcurrentBagConcurrently(bag);

            Assert.IsType<List<int>>(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void GivenAConcurrentBag_WhenReadingFromAConcurrentBag_ThenReturnsAList()
        {
            var bag = ConcurrentBagDemo.CreateAndAddToConcurrentBagConcurrently();
            var result = ConcurrentBagDemo.AccessItemFromAConcurrentBag(bag);

            Assert.IsType<List<int>>(result);
            Assert.Single(result);
        }

        [Fact]
        public void GivenAConcurrentBag_WhenConvertingToAnArray_ThenReturnsAnArray()
        {
            var bag = ConcurrentBagDemo.CreateAndAddToConcurrentBagConcurrently();
            var result = ConcurrentBagDemo.ConcurrentBagToArrayMethod(bag);

            Assert.IsType<int[]>(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void GivenAConcurrentBagFilledOnOneThread_WhenDrainingOnThatThread_ThenReturnsItemsLastInFirstOut()
        {
            var result = ConcurrentBagDemo.DrainOwnQueue();

            Assert.Equal(new List<int> { 5, 4, 3, 2, 1 }, result);
        }

        [Fact]
        public void GivenAConcurrentBagFilledOnOneThread_WhenDrainingOnADifferentThread_ThenReturnsItemsOldestFirst()
        {
            var result = ConcurrentBagDemo.DrainStolenQueue();

            Assert.Equal(new List<int> { 0, 1, 2, 3, 4 }, result);
        }

        [Fact]
        public void GivenAConcurrentBag_WhenClearingAConcurrentBag_ThenReturnsAnEmptyConcurrentBag()
        {
            var bag = ConcurrentBagDemo.CreateAndAddToConcurrentBagConcurrently();

            ConcurrentBagDemo.ConcurrentBagClearMethod(bag);

            Assert.True(bag.IsEmpty);
            Assert.Empty(bag);
        }

        [Fact]
        public void GivenAConcurrentBag_WhenCopyingToAnArray_ThenReturnsAnArray()
        {
            var bag = ConcurrentBagDemo.CreateAndAddToConcurrentBagConcurrently();
            var result = ConcurrentBagDemo.ConcurrentBagCopyToMethod(bag);

            Assert.IsType<int[]>(result);
            Assert.NotEmpty(result);
        }
    }
}