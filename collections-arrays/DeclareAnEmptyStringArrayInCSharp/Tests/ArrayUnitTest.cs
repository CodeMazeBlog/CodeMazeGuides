using EmptyStringArrayFactory;
namespace Tests
{
    public class ArrayUnitTest
    {
        [Fact]
        public void WhenCreateWithNewAndZeroLengthIsCalled_ThenReturnAnEmptyStringArray()
        {
            var actual = ArrayFactory.CreateWithNewAndZeroLength();

            Assert.NotNull(actual);
            Assert.IsType<string[]>(actual);
            Assert.Empty(actual);
        }

        [Fact]
        public void WhenCreateWithEmptyInitializerIsCalled_ThenReturnAnEmptyStringArray()
        {
            var actual = ArrayFactory.CreateWithEmptyInitializer();

            Assert.NotNull(actual);
            Assert.IsType<string[]>(actual);
            Assert.Empty(actual);
        }

        [Fact]
        public void WhenCreateWithImplicitInitializerIsCalled_ThenReturnAnEmptyStringArray()
        {
            var actual = ArrayFactory.CreateWithImplicitInitializer();

            Assert.NotNull(actual);
            Assert.IsType<string[]>(actual);
            Assert.Empty(actual);
        }

        [Fact]
        public void WhenCreateWithEnumerableEmptyIsCalled_ThenReturnAnEmptyStringArray()
        {
            var actual = ArrayFactory.CreateWithEnumerableEmpty();

            Assert.NotNull(actual);
            Assert.IsType<string[]>(actual);
            Assert.Empty(actual);
        }

        [Fact]
        public void WhenCreateWithEnumerableRepeatEmptyStringIsCalled_ThenReturnAnEmptyStringArray()
        {
            var actual = ArrayFactory.CreateWithEnumerableRepeatEmptyString();

            Assert.NotNull(actual);
            Assert.IsType<string[]>(actual);
            Assert.Empty(actual);
        }

        [Fact]
        public void WhenCreateWithEnumerableRepeatStringEmptyIsCalled_ThenReturnAnEmptyStringArray()
        {
            var actual = ArrayFactory.CreateWithEnumerableRepeatStringEmpty();

            Assert.NotNull(actual);
            Assert.IsType<string[]>(actual);
            Assert.Empty(actual);
        }

        [Fact]
        public void WhenCreateWithArrayEmptyIsCalled_ThenReturnAnEmptyStringArray()
        {
            var actual = ArrayFactory.CreateWithArrayEmpty();

            Assert.NotNull(actual);
            Assert.IsType<string[]>(actual);
            Assert.Empty(actual);
        }

        [Fact]
        public void WhenCreateEmptyArrayWithCollectionExpressionIsCalled_ThenReturnAnEmptyStringArray()
        {
            var actual = ArrayFactory.CreateEmptyArrayWithCollectionExpression();

            Assert.NotNull(actual);
            Assert.IsType<string[]>(actual);
            Assert.Empty(actual);
        }

        [Fact]
        public void WhenCreateWithArrayEmptyIsCalledTwice_ThenBothCallsReturnTheSameInstance() =>
            Assert.Same(ArrayFactory.CreateWithArrayEmpty(), ArrayFactory.CreateWithArrayEmpty());

        [Fact]
        public void WhenCreateWithCollectionExpressionIsCalled_ThenItReturnsTheArrayEmptyInstance() =>
            Assert.Same(Array.Empty<string>(), ArrayFactory.CreateEmptyArrayWithCollectionExpression());
    }
}
