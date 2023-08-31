using System.Collections.Immutable;
using Xunit;

namespace ImmutableCollectionsInCSharpTests
{
    public class ImmutableCollectionsTests
    {
        [Fact]
        public void GivenImmutablStack()
        {
            var stack1 = ImmutableStack.Create<int>();
            var stack2 = stack1.Push(1);
            var stack3 = stack2.Push(2);

            Assert.Equal(1, stack2.Peek());

            var stack4 = stack3.Push(4);
            var stack5 = stack4.Pop();

            Assert.Equal(4, stack4.Peek());
            Assert.Equal(2, stack5.Peek()); 
        }
        
        [Fact]
        public void GivenImmutablLists()
        {
            var list1 = ImmutableList.Create<int>(); 
            Assert.Empty(list1); 
            
            var list2 = list1.Add(1); 
            Assert.Single(list2); 
            
            var list3 = list2.Add(2); 
            Assert.Equal(2, list3.Count); 
            
            var list4 = list3.Add(3); 
            Assert.Equal(3, list4.Count); 
            
            var list5 = list4.Replace(2, 4); 
            Assert.Equal(3, list5.Count);
        }

        [Fact]
        public void GivenImmutableArray()
        {
            var immutableArray = ImmutableArray.Create<int>(1, 2, 3, 4);

            var firstElement = immutableArray[0];
            Assert.Equal(1, firstElement);

            var lastElementIndex = immutableArray.BinarySearch(4);
            Assert.Equal(3, lastElementIndex);
        }

        [Fact]
        public void GivenImmutableDictionary()
        {
            var dict1 = ImmutableDictionary.Create<int, char>();
            var dict2 = dict1.Add(1, 'a');

            Assert.Single(dict2);
            Assert.True(dict2.ContainsKey(1));
            Assert.Equal('a', dict2[1]);

            var dict3 = dict2.Add(2, 'b');
            Assert.Equal(2, dict3.Count);

            var dict4 = dict3.Remove(2);
            Assert.Single(dict4);
        }

        [Fact]
        public void GivenImmutablSortedSet()
        {
            var sortedSet1 = ImmutableSortedSet<int>.Empty;

            var sortedSet2 = sortedSet1.Add(5);
            var sortedSet3 = sortedSet2.Add(1);
            Assert.Equal(1, sortedSet3[0]);
            Assert.Equal(5, sortedSet3[1]);
            
            var sortedSet4 = sortedSet2.Add(1);
            Assert.Equal(2, sortedSet4.Count);

            var sortedSet5 = sortedSet4.Remove(1);
            Assert.Single(sortedSet5);
        }
    }
}