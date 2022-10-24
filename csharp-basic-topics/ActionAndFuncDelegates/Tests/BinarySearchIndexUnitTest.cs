using ActionAndFuncDelegates;

namespace Tests
{
    public class BinarySearchIndexUnitTest
    {
        private readonly IEnumerable<int> testData = new int[]{1, 3, 2, 5, 4};
        private BinarySearchIndex sut;

        [SetUp]
        public void Setup()
        {
            sut = new BinarySearchIndex(testData, BinarySearchIndex.DefaultIntOrder);
        }

        [Test]
        public void GivenTheTestDataContainsValue_WhenFindIsCalled_CallsActionForWhenFound()
        {
            bool whenFoundActionCalled = false;

            sut.Find(3, _ => whenFoundActionCalled = true, _ => throw new InvalidOperationException());

            Assert.That(whenFoundActionCalled);
        }

        [Test]
        public void GivenTheTestDataDoesntContainValue_WhenFindIsCalled_CallsActionForWhenNotFound()
        {
            bool whenNotFoundActionCalled = false;

            sut.Find(6, _ => throw new InvalidOperationException(), _ => whenNotFoundActionCalled = true);

            Assert.That(whenNotFoundActionCalled);
        }

        [Test]
        public void GivenTheDataSetIsEmpty_WhenFindIsCalled_CallsActionForWhenNotFound()
        {
            sut = new BinarySearchIndex(Enumerable.Empty<int>(), BinarySearchIndex.DefaultIntOrder);
            bool whenNotFoundActionCalled = false;

            sut.Find(1, _ => throw new InvalidOperationException(), _ => whenNotFoundActionCalled = true);

            Assert.That(whenNotFoundActionCalled);
        }
    }
}