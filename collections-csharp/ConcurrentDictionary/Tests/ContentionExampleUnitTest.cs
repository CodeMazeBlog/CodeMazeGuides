using System.Diagnostics;

namespace Tests
{
    public class ContentionExampleUnitTest
    {
        private int expectedEntryValue = ContentionExample.ProcessingSteps * ContentionExample.MaxIterations / ContentionExample.MaxStateEntries;
        private ContentionExample sut = new ContentionExample();

        [SetUp]
        public void SetUp()
        {
            sut = new ContentionExample();
        }

        [Test]
        public void WhenRunFirstVariant_ThenAllStateEntriesHaveExpectedValue()
        {
            sut.RunFirstVariant();

            Assert.IsFalse(sut.State.Where(entry => entry != expectedEntryValue).Any());
        }

        [Test]
        public void WhenRunSecondVariant_ThenAllStateEntriesHaveExpectedValue()
        {
            sut.RunSecondVariant();

            Assert.IsFalse(sut.State.Where(entry => entry != expectedEntryValue).Any());
        }

        [Test]
        public void WhenBothVariantsRun_ThenTheSecondVariantTakesMoreTime()
        {
            var firstVariant = new ContentionExample();
            var secondVariant = new ContentionExample();

            Stopwatch stopwatch = Stopwatch.StartNew();
            firstVariant.RunFirstVariant();
            var firstVariantTime = stopwatch.ElapsedTicks;

            stopwatch = Stopwatch.StartNew();
            secondVariant.RunSecondVariant();
            var secondVariantTime = stopwatch.ElapsedTicks;

            Assert.Greater(secondVariantTime, firstVariantTime);
        }
    }
}