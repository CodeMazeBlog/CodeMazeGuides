using DelegatesDemo.ActionPracticalUsage;
using NUnit.Framework;
using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace Tests
{
    public class ActionPracticalUsageUnitTest
    {
        [Test]
        public async Task WhenProcessInParallelInvoked_ThenExecutesCallback()
        {
            var collection = new[] { "one", "two", "three" };
            const int batchSize = 2;
            var processedItems = new ConcurrentBag<string>();

           await collection.ProcessInParallel(batchSize, (item) =>
            {
                processedItems.Add(item);
            });         
            
            Assert.AreEqual(collection.Length, processedItems.Count);
        }

        [Test]
        public void WhenProcessInParallelAndWhenNoErrorHandler_ThenThrowsException()
        {
           var collection = new[] { "one", "two", "three" };           

           Assert.ThrowsAsync<Exception>(async () => await collection.ProcessInParallel(1, (item) => throw new Exception(item)));
        }

        [Test]
        public void WhenProcessInParallelAndWhenErrorHandlerProvided_ThenDoesNotThrow()
        {           

            var collection = new[] { "one", "two", "three" };          
 
            Action<Exception> onException = (error) =>
            {
                
            };

             Assert.DoesNotThrowAsync(async () => await collection.ProcessInParallel(1, (item) => throw new Exception(item), onException));
        }
    }
}
