using ConcatenateLists;

namespace Tests
{
    public class Tests
    {
        private readonly List<string> _firstList = new() { "Concatenate", "Lists" };
        private readonly List<string> _secondList = new() { "In", "C#" };
        private readonly Concatenator _concatenator = new();

        private readonly List<string> _expectedList = new() { "Concatenate", "Lists", "In", "C#" };

        [Fact]
        public void GivenTwoLists_WhenUsingAddMethod_ThenReturnANewConcatenatedList()
        {
            var result = _concatenator.UsingAdd(_firstList, _secondList);

            Assert.Equal(_expectedList.Count(), result.Count);
            Assert.Equal(_expectedList, result);
        }

        [Fact]
        public void GivenTwoLists_WhenUsingEnumerableConcatMethod_ThenReturnANewConcatenatedList()
        {
            var result = _concatenator.UsingEnumerableConcat(_firstList, _secondList);

            Assert.Equal(_expectedList.Count(), result.Count);
            Assert.Equal(_expectedList, result);
        }

        [Fact]
        public void GivenTwoLists_WhenUsingEnumerableUnionMethod_ThenReturnANewConcatenatedList()
        {
            var result = _concatenator.UsingEnumerableUnion(_firstList, _secondList);

            Assert.Equal(_expectedList.Count(), result.Count);
            Assert.Equal(_expectedList, result);
        }

        [Fact]
        public void GivenTwoLists_WhenUsingAddRangeMethod_ThenReturnANewConcatenatedList()
        {
            var result = _concatenator.UsingAddRange(_firstList, _secondList);

            Assert.Equal(_expectedList.Count(), result.Count);
            Assert.Equal(_expectedList, result);
        }

        [Fact]
        public void GivenTwoLists_WhenUsingCopyToMethod_ThenReturnANewConcatenatedList()
        {
            var result = _concatenator.UsingCopyTo(_firstList, _secondList);

            Assert.Equal(_expectedList.Count(), result.Count);
            Assert.Equal(_expectedList, result);
        }

        [Fact]
        public void GivenTwoLists_WhenUsingSelectManyMethod_ThenReturnANewConcatenatedList()
        {
            var result = _concatenator.UsingSelectMany(_firstList, _secondList);

            Assert.Equal(_expectedList.Count(), result.Count);
            Assert.Equal(_expectedList, result);
        }
    }
}