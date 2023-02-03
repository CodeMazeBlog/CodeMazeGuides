namespace ActionPredikateandFuncExample
{
    internal class DisplayCorrectTypes
    {
        public void Test()
        {
            var variable = 5;
            var variable1 = TestMethod1;
            var variable2 = TestMethod2;
            var variable3 = TestMethod3;

            variable1();
            variable2(variable);
            variable3(1, "test");
        }

        private void TestMethod1()
        {
            Console.WriteLine("Test method1");
        }

        private void TestMethod2(int number)
        {
            Console.WriteLine($"Test method2 with paramer {number}");
        }

        private void TestMethod3(int number, string text)
        {
            Console.WriteLine($"Test method3 with paramers {number} and {text}");
        }
    }
}
