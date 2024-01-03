
namespace ThreadSleepVsTaskDelay.Test
{
    public class ProgramTest
    {
        private const int DelayMilliseconds = 50;

        [Fact]
        public async Task WhenCallUseTaskDelay_ThenDelayIsTwoThousandOrMoreMilliseconds()
        {
            // Arrange
            var stopwatch = new Stopwatch();

            // Act
            stopwatch.Start();
            await Program.UseTaskDelay(DelayMilliseconds).ConfigureAwait(false);
            stopwatch.Stop();

            // Assert
            Assert.True(stopwatch.ElapsedMilliseconds >= DelayMilliseconds);
        }

        [Fact]
        public void WhenCallUseThreadSleep_ThenDelayIsTwoThousandOrMoreMilliseconds()
        {
            // Arrange
            var stopwatch = new Stopwatch();

            // Act
            stopwatch.Start();
            Program.UseThreadSleep(DelayMilliseconds);
            stopwatch.Stop();

            // Assert
            Assert.True(stopwatch.ElapsedMilliseconds >= DelayMilliseconds);
        }

        [Fact]
        public void WhenCallUseThreadSleep_ThenThreadIdRemainsTheSame()
        {
            // Arrange
            var threadIdBefore = Environment.CurrentManagedThreadId;

            // Act
            Program.UseThreadSleep(DelayMilliseconds);
            var threadIdAfter = Environment.CurrentManagedThreadId;

            // Assert
            Assert.Equal(threadIdBefore, threadIdAfter);
        }
    }
}
