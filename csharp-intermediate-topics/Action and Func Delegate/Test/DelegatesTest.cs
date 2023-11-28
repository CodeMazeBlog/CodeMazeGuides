using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Action_and_Func_Delegate;

namespace Test
{
    [TestFixture]
    public class DelegatesTest
    {
        [Test]
        public void TestGetEvenNumbers()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Func<int, bool> isEven = num => num % 2 == 0;

            IEnumerable<int> evenNumbers = Program.GetEvenNumbers(numbers, isEven); 
            Assert.AreEqual(new List<int> { 2, 4, 6, 8, 10 }, evenNumbers);
        }

        [Test]
        public void TestPrintNumbers()
        {
            var writer = new StringWriter();
            Console.SetOut(writer);

            IEnumerable<int> numbers = new List<int> { 2, 4, 6, 8, 10 };
            Action<IEnumerable<int>> printNumbers = list => list.ToList().ForEach(Console.WriteLine);

            printNumbers(numbers);

            string output = writer.GetStringBuilder().ToString().Trim();
            Assert.AreEqual("2\r\n4\r\n6\r\n8\r\n10", output);
        }
    }
}
