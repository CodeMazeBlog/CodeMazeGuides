using System.Collections.Immutable;
using System.Linq;
using Xunit;

namespace ImmutableCollectionsInCSharpTests
{
    public class ImmutableCollectionsTests
    {
        [Fact]
        public void ExploreImmutablStack()
        {
            var stack1 = ImmutableStack<int>.Empty;
            var stack2 = stack1.Push(1);
            var stack3 = stack2.Push(2);

            Assert.Equal(1, stack2.Peek());

            var stack4 = stack3.Push(4);
            var stack5 = stack4.Pop();

            Assert.Equal(4, stack4.Peek());
            Assert.Equal(2, stack5.Peek()); 
        }
        
        [Fact]
        public void ExploreImmutablLists()
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
    }
}