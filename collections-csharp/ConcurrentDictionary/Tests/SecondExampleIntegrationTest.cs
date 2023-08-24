namespace Tests
{
    public class SecondExampleIntegrationTest
    {
        [Test]
        public void WhenRun_ThenStateContainsEntriesWithLowerValueThanExpected()
        {
            int expectedEntryValue = SecondExample.ProcessingSteps * SecondExample.MaxIterations / SecondExample.MaxStateEntries;
            SecondExample sut = new();

            sut.Run();

            Assert.IsTrue(sut.State.Where(entry => entry != expectedEntryValue).Any());
        }
    }
}