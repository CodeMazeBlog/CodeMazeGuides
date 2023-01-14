namespace Tests
{
    public class NaiveExampleUnitTest
    {
        [Test]
        public void WhenRun_ThenStateContainsEntriesWithLowerValueThanExpected()
        {
            int expectedEntryValue = NaiveExample.ProcessingSteps * NaiveExample.MaxIterations / NaiveExample.MaxStateEntries;
            NaiveExample sut = new NaiveExample();

            sut.Run();

            Assert.IsTrue(sut.State.Where(entry => entry != expectedEntryValue).Any());
        }
    }
}