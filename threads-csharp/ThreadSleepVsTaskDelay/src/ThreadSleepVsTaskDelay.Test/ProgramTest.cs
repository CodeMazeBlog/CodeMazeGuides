using System.Diagnostics;

namespace ThreadSleepVsTaskDelay.Test
{
    public class ProgramTest
    {
        [Fact]
        public async Task WhenCallUseTaskDelay_ThenDelayIsTwoThousendOrMoreMilliseconds()
        {
            // Arrange
            var stopwatch = new Stopwatch();

            // Act
            stopwatch.Start();
            await Program.UseTaskDelay();
            stopwatch.Stop();

            // Assert
            Assert.True(stopwatch.ElapsedMilliseconds >= 2000);
        }

        [Fact]
        public void WhenCallUseThreadSleep_ThenDelayIsTwoThousendOrMoreMilliseconds()
        {
            // Arrange
            var stopwatch = new Stopwatch();

            // Act
            stopwatch.Start();
            Program.UseThreadSleep();
            stopwatch.Stop();

            // Assert
            Assert.True(stopwatch.ElapsedMilliseconds >= 2000);
        }

        [Fact]
        public void WhenCallUseThreadSleep_ThenThreadIdRemainsTheSame()
        {
            // Arrange
            var threadIdBefore = Environment.CurrentManagedThreadId;

            // Act
            Program.UseThreadSleep();
            var threadIdAfter = Environment.CurrentManagedThreadId;

            // Assert
            threadIdBefore.Equals(threadIdAfter);
        }
    }
}
