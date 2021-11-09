using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Test
{
    [TestClass]
    public class FuncAndActionDelegatesUnitTest
    {
        private delegate int MyDelegate(int number);

        [TestMethod]
        public void AddWithDelegate()
        {
            MyDelegate AddOne = (int n) =>
            {
                return n + 1;
            };
            MyDelegate AddTwo = (int n) =>
            {
                return n + 2;
            };
            var x = AddOne(3); // x == 4
            var y = AddTwo(3); // y == 5
            Assert.IsTrue(x == 4);
            Assert.IsTrue(y == 5);
        }
        [TestMethod]
        public void AddWithFunc()
        {
            Func<int, int> AddOne = num => num + 1;
            var x = AddOne(3); // x == 4
            Assert.IsTrue(x == 4);
        }

        private void HandleNumbers(Action<int> callback)
        {
            int n = 10;
            // ... do something interesting with 'n', maybe allow user to pick a number?
            callback(n);
        }

        [TestMethod]
        public void AddWithCallback()
        {
            int acc = 0;
            HandleNumbers(i => acc += i); // acc == 10
            Assert.IsTrue(acc == 10);
        }
        [TestMethod]
        public void MultiplyWithCallback()
        {
            int mul = 1;
            HandleNumbers(i => mul *= (i + 1)); // mul == 11
            Assert.IsTrue(mul == 11);
        }

        private void ForEach<T>(IEnumerable<T> source, Action<T> action)
        {
            foreach (var item in source) action(item);
        }

        public int AddWithForEach()
        {
            List<int> MyNumbers = new List<int>() { 1, 2, 3 };
            int acc = 0;
            int mul = 1;
            ForEach(MyNumbers, x => acc += x);
            ForEach(MyNumbers, x => mul *= x);
            return acc;
        }
        public int MultiplyWithForEach()
        {
            List<int> MyNumbers = new List<int>() { 1, 2, 3 };
            int mul = 1;
            ForEach(MyNumbers, x => mul *= x);
            return mul;
        }
    }
}
