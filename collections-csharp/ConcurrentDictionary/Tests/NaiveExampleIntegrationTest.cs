namespace Tests
{
    public class NaiveExampleIntegrationTest
    {
        [Test]
        public void WhenRun_ThenStateContainsEntriesWithLowerValueThanExpected()
        {
            int expectedEntryValue = NaiveExample.ProcessingSteps * NaiveExample.MaxIterations / NaiveExample.MaxStateEntries;
            NaiveExample sut = new();

            sut.Run();

            Assert.IsTrue(sut.State.Where(entry => entry != expectedEntryValue).Any());
        }
    }
}