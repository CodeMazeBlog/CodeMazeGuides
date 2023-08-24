namespace Tests
{
    public class MemoryLeakExampleIntegrationTest
    {
        private int expectedEntryValue = MemoryLeakExample.ProcessingSteps * MemoryLeakExample.MaxIterations / MemoryLeakExample.MaxStateEntries;

        private MemoryLeakExample sut = new();

        [SetUp]
        public void SetUp()
        {
            sut = new();
        }

        [Test]
        public void WhenRun_ThenAllStateEntriesHaveExpectedValue()
        {
            sut.Run();

            Assert.IsFalse(sut.State.Where(entry => entry != expectedEntryValue).Any());
        }

        [Test]
        public void WhenRun_ThenInitialValueIsCreatedMultipleTimesForAtLeastOneKey()
        {
            sut.Run();

            Assert.IsTrue(sut.NewValueCreated.Where(entry => entry > 1).Any());
        }

        [Test]
        public void WhenRun_ThenUpdateValueIsCreatedMoreTimesThanExpectedForAtLeastOneKey()
        {
            sut.Run();

            Assert.IsTrue(sut.UpdateValueCreated.Where(entry => entry > expectedEntryValue - 1).Any());
        }
    }
}