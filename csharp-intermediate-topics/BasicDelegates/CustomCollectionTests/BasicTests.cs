using System;
using Xunit;

namespace CustomCollectionTests
{

    public class BasicTests
    {
        [Fact]
        public void TestTransform()
        {
            var collection = new CustomCollection<MyInteger>(new[] { new MyInteger(2), new MyInteger(4), new MyInteger(6) });
            var expected = new CustomCollection<MyInteger>(new[] { new MyInteger(4), new MyInteger(8), new MyInteger(12) });

            collection.Transform((current) => current.Value = current.Value * 2);

            Assert.Equal(expected, collection);
        }

        [Fact]
        public void TestFiltering()
        {
            var collection = new CustomCollection<MyInteger>(new[]
            {
                new MyInteger(1),
                new MyInteger(2),
                new MyInteger(3),
                new MyInteger(4),
                new MyInteger(5),
                new MyInteger(6)
            });

            var expected = new CustomCollection<MyInteger>(new[]
            {
                new MyInteger(1),
                new MyInteger(3),
                new MyInteger(5)
            });

            var resultCollection = collection.Filter((current) => (current.Value % 2) != 0);

            Assert.Equal(expected, resultCollection);
        }

        // This test shows it more explicitly
        void TestTransformAction(MyInteger item)
        {
            item.Value *= 2;
        }

        [Fact]
        public void TestLongerSyntaxForTransformAction()
        {
            var collection = new CustomCollection<MyInteger>(new[] { new MyInteger(2), new MyInteger(4), new MyInteger(6) });
            var expected = new CustomCollection<MyInteger>(new[] { new MyInteger(4), new MyInteger(8), new MyInteger(12) });

            // We can store it like a variable!
            Action<MyInteger> transformAction = TestTransformAction;

            // Then we can pass it like a variable!
            collection.Transform(transformAction);

            Assert.Equal(expected, collection);
        }

        bool TestFilterFunc(MyInteger item)
        {
            return (item.Value % 2) != 0;
        }

        [Fact]
        public void TestLongerSyntaxForFilterFunc()
        {
            var collection = new CustomCollection<MyInteger>(new[]
            {
                new MyInteger(1),
                new MyInteger(2),
                new MyInteger(3),
                new MyInteger(4),
                new MyInteger(5),
                new MyInteger(6)
            });

            var expected = new CustomCollection<MyInteger>(new[]
            {
                new MyInteger(1),
                new MyInteger(3),
                new MyInteger(5)
            });

            // Again - we are using it like a variable!
            Func<MyInteger, bool> filterFunc = TestFilterFunc;

            var resultCollection = collection.Filter(filterFunc);

            Assert.Equal(expected, resultCollection);
        }
    }
}