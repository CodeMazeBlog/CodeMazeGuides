using System.Diagnostics;

namespace Tests
{
    public class ContentionExampleIntegrationTest
    {
        private int expectedEntryValue = ContentionExample.ProcessingSteps * ContentionExample.MaxIterations / ContentionExample.MaxStateEntries;
        private ContentionExample sut = new();

        [SetUp]
        public void SetUp()
        {
            sut = new();
        }

        [Test]
        public void WhenRunFirstVariant_ThenAllStateEntriesHaveExpectedValue()
        {
            sut.RunWithEntryCheck();

            Assert.IsFalse(sut.State.Where(entry => entry != expectedEntryValue).Any());
        }

        [Test]
        public void WhenRunSecondVariant_ThenAllStateEntriesHaveExpectedValue()
        {
            sut.RunWithKeysCheck();

            Assert.IsFalse(sut.State.Where(entry => entry != expectedEntryValue).Any());
        }

        [Test]
        public void WhenBothVariantsRun_ThenTheSecondVariantTakesMoreTime()
        {
            ContentionExample firstVariant = new();
            ContentionExample secondVariant = new();

            Stopwatch stopwatch = Stopwatch.StartNew();
            firstVariant.RunWithEntryCheck();
            var firstVariantTime = stopwatch.ElapsedTicks;

            stopwatch = Stopwatch.StartNew();
            secondVariant.RunWithKeysCheck();
            var secondVariantTime = stopwatch.ElapsedTicks;

            Assert.Greater(secondVariantTime, firstVariantTime);
        }
    }
}