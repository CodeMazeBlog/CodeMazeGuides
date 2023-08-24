namespace Tests
{
    [TestClass]
    public class MultipleFrameworkTargetUnitTests
    {
        [TestMethod]
        public void TestMethodForAllFrameworks()
        {
            Console.WriteLine("Hello, World!");
            Assert.IsTrue(true);
        }

#if NET7_0
        [TestMethod]
        public void TestMethodForNet7()
        {
            Console.WriteLine(".NET 7 - Hello from the latest .NET framework!");
            Assert.IsTrue(true);
        }

#elif NETCOREAPP3_1
        [TestMethod]
        public void TestMethodForNetCore3_1()
        {
            Console.WriteLine(".NET Core 3.1 - Hello from a previous LTS version of .NET Core!");
            Assert.IsTrue(true);
        }
#endif
    }
}