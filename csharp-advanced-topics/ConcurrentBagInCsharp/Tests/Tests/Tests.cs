using ConcurrentBag;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
	delegate string PrintMessage(string text);
	delegate T Print<T>(T param1);

	[TestClass]
	public class Tests
	{
		public readonly ConcurrentBagImplementation _ConcurrentBagImplementation = new ConcurrentBagImplementation();

		[TestMethod]
		public void GivenAnArray_WhenInitializongCollection_ThenReturnAllValues()
		{
			var input = new int[] { 23, 24 };
			var concurrentBag = _ConcurrentBagImplementation.CreateConcurrentBag(input);
			Assert.IsNotNull(concurrentBag);
			Assert.AreEqual(concurrentBag.Count, input.Length);

			concurrentBag.TryPeek(out int result);
			Assert.IsTrue(Array.IndexOf(input, result) >= 0);

			concurrentBag.TryTake(out result);
			Assert.IsTrue(Array.IndexOf(input, result) >= 0);

			Assert.IsTrue(concurrentBag.Count < input.Length);
		}


		[TestMethod]
		public void GivenInputArray_WhenTwoTaskIsRunning_ThenReturnSum()
		{
			var input1 = new List<int> { 10, 20, 200, 40, 80, 50 };
			var input2 = new List<int> { 23, 24, 30, 1, 50, 100 };
			var totalSum = input1.Sum() + input2.Sum();
			var result = _ConcurrentBagImplementation.MultiThread_Implementation(input1,input2);
			Assert.IsTrue(result.Item1 != input1.ToList().Sum());
			Assert.IsFalse(result.Item2 > input2.ToList().Sum());
			Assert.IsTrue(result.Item3 > 0);
			Assert.IsTrue(result.Item3 + result.Item2 + result.Item1 == totalSum);
		}
	}
}
