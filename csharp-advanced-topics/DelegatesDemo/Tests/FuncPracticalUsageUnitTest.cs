using DelegatesDemo.FuncPracticalUsage;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class FuncPracticalUsageUnitTest
    {
        [Test]
        public void WhenRetryHelperIsPassedCallback_ThenCallbackIsExecuted()
        {
            Dictionary<int, string> storage = new();
            storage.Add(1, "Jonn");
            storage.Add(2, "Kara");
            storage.Add(3, "Winn");
            storage.Add(4, "James");

            var retriveFunc = new Func<string>(() =>
            {
                var name = storage[3];
                return name;
            });

            var nameFromStorage = RetryHelper.RetryOnException(retriveFunc, 3, TimeSpan.FromSeconds(5));

            Assert.AreEqual("Winn", nameFromStorage);
;        }

        [Test]
        public void WhenRetryHelperCallbackThrowsExeption_ThenCallbackLogicIsRetried()
        {
            Dictionary<int, string> storage = new();
            storage.Add(1, "Jonn");
            storage.Add(2, "Kara");
            storage.Add(3, "Winn");
            storage.Add(4, "James");
            var numberOfExecutions = 0;

            var retriveFunc = new Func<string>(() =>
            {
                var name = storage[3];
                numberOfExecutions++;
                throw new Exception("Some Exception");
                
            });

            

            Assert.Throws<Exception>(() => RetryHelper.RetryOnException(retriveFunc, 3, TimeSpan.FromSeconds(1)), "Some Exception");
            Assert.AreEqual(4, numberOfExecutions);
            ;
        }
    }
}
