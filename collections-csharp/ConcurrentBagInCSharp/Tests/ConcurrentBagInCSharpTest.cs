using ConcurrentBagInCSharp;
using System.Collections;
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
        public void GivenAConcurrentBag_WhenRemovingFromAConcurrentBag_ThenReturnsAnArrayList()
        {
            var bag = ConcurrentBagDemo.CreateAndAddToConcurrentBagConcurrently();
            var result = ConcurrentBagDemo.RemoveFromConcurrentBag(bag);

            Assert.IsType<ArrayList>(result);
            Assert.Single(result);
        }

        [Fact]
        public void GivenAConcurrentBag_WhenRemovingFromAConcurrentBagConcurrently_ThenReturnsAnArrayList()
        {
            var bag = ConcurrentBagDemo.CreateAndAddToConcurrentBagConcurrently();
            var result = ConcurrentBagDemo.RemoveFromConcurrentBagConcurrently(bag);

            Assert.IsType<ArrayList>(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void GivenAConcurrentBag_WhenReadingFromAConcurrentBag_ThenReturnsAnArrayList()
        {
            var bag = ConcurrentBagDemo.CreateAndAddToConcurrentBagConcurrently();
            var result = ConcurrentBagDemo.AccessItemFromAConcurrentBag(bag);

            Assert.IsType<ArrayList>(result);
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
        public void GivenAConcurrentBag_WhenCopyingToAnArray_ThenReturnsAnArray()
        {
            var bag = ConcurrentBagDemo.CreateAndAddToConcurrentBagConcurrently();
            var result = ConcurrentBagDemo.ConcurrentBagCopyToMethod(bag);

            Assert.IsType<int[]>(result);
            Assert.NotEmpty(result);
        }
    }
}