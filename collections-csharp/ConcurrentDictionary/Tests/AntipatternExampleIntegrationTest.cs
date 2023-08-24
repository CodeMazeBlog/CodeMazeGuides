namespace Tests
{
    public class AntipatternExampleIntegrationTest
    {
        [Test]
        public void WhenRun_ThenStateContainsEntriesWithLowerValueThanExpected()
        {
            int expectedEntryValue = AntipatternExample.ProcessingSteps * AntipatternExample.MaxIterations / AntipatternExample.MaxStateEntries;
            AntipatternExample sut = new();

            sut.Run();

            Assert.IsTrue(sut.State.Where(entry => entry != expectedEntryValue).Any());
        }
    }
}