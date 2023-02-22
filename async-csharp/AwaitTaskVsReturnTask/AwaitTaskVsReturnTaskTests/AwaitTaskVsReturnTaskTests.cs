using System;
using System.IO;
using Xunit;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace AwaitTaskVsReturnTaskTests
{
    public class AwaitTaskVsReturnTaskUnitTest
    {
        private static Task SimpleTask(int duration)
        {
            if (duration > 1000)
                throw new Exception("I don't want to delay so long");

            return Task.Delay(duration);
        }

        private static async Task SimpleTaskAsync(int duration)
        {
            if (duration > 1000)
                throw new Exception("I don't want to delay so long");

            await Task.Delay(1000);
        }

        [Fact]
        public async Task GivenTaskWithException_WhenReturned_ThenImmediatelyThrowsException()
        {
            Task? task = null;

            // Throws exception when we call the method
            await Assert.ThrowsAsync<Exception>(() => task = SimpleTask(2000));

            Assert.Null(task);
        }

        [Fact]
        public async Task GivenTaskWithException_WhenAwaited_ThenCarriesExceptionWithTask()
        {
            // Does not throw exception when we call the method
            var task = SimpleTaskAsync(2000);

            Assert.NotNull(task);

            // Throws exception while executing the task
            await Assert.ThrowsAsync<Exception>(async () => await task);

            Assert.True(task.IsFaulted);
        }

        private static async Task<string> ReadTaskAsync()
        {
            using (var reader = new DataReader())
                return await reader.ReadAsync();
        }

        private static Task<string> ReadTask()
        {
            using (var reader = new DataReader())
                return reader.ReadAsync();
        }

        [Fact]
        public async Task GivenTaskFromDisposableObject_WhenAwaited_ThenDisposeInvokedAfterTaskCompletion()
        {
            var resultOfAwaitedTask = await ReadTaskAsync();

            Assert.Equal("Dispose invoked after reading completed", resultOfAwaitedTask);
        }

        [Fact]
        public async Task GivenTaskFromDisposableObject_WhenReturned_ThenDisposeInvokedBeforeTaskCompletion()
        {
            var resultOfReturnedTask = await ReadTask();

            Assert.Equal("Dispose invoked before reading completed", resultOfReturnedTask);
        }

        // Bad code - this will cause deadlock if called from UI thread
        // Won't be a problem in Console or ASP.NET Core application
        private string ReadContent()
        {
            var task = ReadContentTaskAsync();

            return task.Result;
        }

        private async Task<string> ReadContentTaskAsync()
        {
            await Task.Delay(2000);

            return "Sample content";
        }

        [Fact]
        public void GivenAsyncTask_WhenBlockedInNonUIThread_ThenDoesNotCauseDeadlock()
        {
            var result = ReadContent();

            Assert.Equal("Sample content", result);
        }

        private static AsyncLocal<string> context = new AsyncLocal<string>();

        private const string ParentValue = "Parent";
        private const string ChildAsyncValue = "ChildAsync";
        private const string ChildNonAsyncValue = "ChildNonAsync";

        [Fact]
        public async Task ParentTaskCallingAsyncChildTask()
        {
            context.Value = ParentValue;

            Assert.Equal(ParentValue, context.Value);

            await ChildTaskAsync();

            Assert.Equal(ParentValue, context.Value);
        }

        private static async Task ChildTaskAsync()
        {
            Assert.Equal(ParentValue, context.Value);

            context.Value = ChildAsyncValue;
            await Task.Yield();

            Assert.Equal(ChildAsyncValue, context.Value);
        }

        [Fact]
        public async Task ParentTaskCallingNonAsyncChildTask()
        {
            context.Value = ParentValue;

            Assert.Equal(ParentValue, context.Value);

            await ChildTask();

            Assert.Equal(ChildNonAsyncValue, context.Value);
        }

        private static Task ChildTask()
        {
            Assert.Equal(ParentValue, context.Value);

            context.Value = ChildNonAsyncValue;

            Assert.Equal(ChildNonAsyncValue, context.Value);

            return Task.CompletedTask;
        }

        [Fact]
        public async void GivenNonAsyncOverloadOfAsyncTask_WhenGetsCalled_ThenProducesExpectedOutcome()
        {
            var result = await CalculateTask();

            Assert.Equal(3.5m, result);
        }

        private async Task<decimal> CalculateTaskAsync(bool roundUp)
        {
            await Task.Delay(100);

            return roundUp ? 3.5m : 3.48m;
        }

        private Task<decimal> CalculateTask() => CalculateTaskAsync(true);
    }
}