using ConcurrentBag;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
	delegate string PrintMessage(string text);
	delegate T Print<T>(T param1);

	[TestClass]
	public class Tests
	{
		public readonly ConcurrentBagImplementation _ConcurrentBagImplementation = new ConcurrentBagImplementation();

		[TestMethod]
		public void whenTaskIsRunning_AddtoconcurrencyBag()
		{
			var result = _ConcurrentBagImplementation.UpdateConcurrentBag();
			Assert.IsNotNull(result);
		}

	}
}
