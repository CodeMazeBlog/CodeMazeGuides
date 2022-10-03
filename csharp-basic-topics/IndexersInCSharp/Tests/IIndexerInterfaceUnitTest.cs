using IndexersInCSharp;
using Xunit;

namespace Tests
{
    public class IIndexerInterfaceUnitTest
    {
        [Fact]
        public void WhenCreateInstanceFromInterfaceWithCallingIndexerThatHaveNoBody_ThenTheIndexerCallsFromClass()
        {
            IIndexerInterface indexerInteface = new IndexerClass();
            var actual = indexerInteface[0];

            var expected = "Hello from class.";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WhenCreateInstanceFromInterfaceWithCallingIndexerThatHaveADefaultBody_ThenTheIndexerCallsFromInterface()
        {
            IIndexerInterface indexerInteface = new IndexerClass();
            var actual = indexerInteface[""];

            var expected = "Hello from interface.";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WhenCreateInstanceFromConcreteClass_ThenTheIndexerCallsFromClass()
        {
            IndexerClass indexerClass = new IndexerClass();
            var actual = indexerClass[0];

            var expected = "Hello from class.";

            Assert.Equal(expected, actual);
        }
    }
}
