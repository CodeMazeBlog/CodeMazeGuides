using System;
using System.Threading.Tasks;
using NUnit.Framework;
using TaskExtensions = MultipleTasksDemo.Client.Extensions.TaskExtensions;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void WhenAll_ThrowsAggregateException()
        {
            var t1 = Task.Run(async () =>
            { 
                 await Task.Delay(10);
                 throw new Exception("Test Exception 1");
                 return 1;
            });
            var t2 = Task.Run(async () =>
            {
                await Task.Delay(10);
                throw new Exception("Test Exception 2");
                return 2;
            });
            var t3 = Task.Run(async () =>
            {
                await Task.Delay(10);
                return 3;
            });

            Assert.ThrowsAsync<AggregateException>(async () => { var (result1, result2, result3) = await TaskExtensions.WhenAll(t1, t2, t3); });
        }

        [Test]
        public void WhenAll_ReturnsIndividualExceptionsOnEachTask()
        {
            var t1 = Task.Run(async () =>
            {
                await Task.Delay(10);
                throw new Exception("Test Exception 1");
                return 1;
            });
            var t2 = Task.Run(async () =>
            {
                await Task.Delay(10);
                throw new Exception("Test Exception 2");
                return 2;
            });
            var t3 = Task.Run(async () =>
            {
                await Task.Delay(10);
                return 3;
            });

            var aggregateException = Assert.ThrowsAsync<AggregateException>(async () => { var (result1, result2, result3) = await TaskExtensions.WhenAll(t1, t2, t3); });

            Assert.AreEqual(2, aggregateException?.InnerExceptions.Count);
            Assert.AreEqual("Test Exception 1", aggregateException?.InnerExceptions[0].Message);
            Assert.AreEqual("Test Exception 2", aggregateException?.InnerExceptions[1].Message);
        }

        [Test]
        public async Task WhenAll_ReturnsResultsForEachTask()
        {
            var t1 = Task.Run(async () =>
            {
                await Task.Delay(10);
                return 1;
                              });
            var t2 = Task.Run(async () =>
            {
                await Task.Delay(10);
                return 2;
            });
            var t3 = Task.Run(async () =>
            {
                await Task.Delay(10);
                return 3;
            });

            var (result1, result2, result3) = await TaskExtensions.WhenAll(t1, t2, t3);

            Assert.AreEqual(1, result1);
            Assert.AreEqual(2, result2);
            Assert.AreEqual(3, result3);
        }

    }
}