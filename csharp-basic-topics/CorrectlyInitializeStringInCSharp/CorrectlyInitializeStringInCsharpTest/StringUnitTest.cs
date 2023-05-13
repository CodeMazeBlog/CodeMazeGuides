using CorrectlyInitializeStringInCSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CorrectlyInitializeStringInCsharpTest
{
    [TestClass]
    public class StringUnitTest
    {

        [TestMethod]
        public void TestMyString1()
        {
            string expected = "Hello, World!";
            string actual = StringExamples.MyString1();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMyString2()
        {
            string expected = "Hello,\nWorld!";
            string actual = StringExamples.MyString2();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestFullName()
        {
            string expected = "John Doe";
            string actual = StringExamples.FullName("John", "Doe");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPath()
        {
            string expected = @"C:\Users\Codemaze\Documents";
            string actual = StringExamples.Path();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMultiLineString()
        {
            string expected = @"This is
            a multi-line
            string.";
            string actual = StringExamples.MultiLineString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestEmptyString()
        {
            string expected = string.Empty;
            string actual = StringExamples.EmptyString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestNullString()
        {
            string? expected = null;
            string? actual = StringExamples.NullString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDefaultString()
        {
            string? expected = default(string);
            string? actual = StringExamples.DefaultString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestStringBuilderString()
        {
            string expected = "Hello World";
            string actual = StringExamples.StringBuilderString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestSumString()
        {
            string expected = "The sum of 5 and 10 is 15";
            string actual = StringExamples.SumString(5, 10);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestAsteriskString()
        {
            string expected = "**********";
            string actual = StringExamples.AsteriskString(10);
            Assert.AreEqual(expected, actual);

        }

    }
}