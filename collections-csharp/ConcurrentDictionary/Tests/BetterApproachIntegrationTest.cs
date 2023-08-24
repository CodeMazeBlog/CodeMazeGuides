namespace Tests
{
    public class BetterApproachIntegrationTest
    {
        [Test]
        public void WhenRun_ThenAllStateEntriesHaveExpectedValue()
        {
            int expectedEntryValue = BetterApproach.ProcessingSteps * BetterApproach.MaxIterations / BetterApproach.MaxStateEntries;
            BetterApproach sut = new();

            sut.Run();

            Assert.IsFalse(sut.State.Where(entry => entry != expectedEntryValue).Any());
        }
    }
}