using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace InitializeArraysTests
{
    [TestClass]
    public class ArrayUnitTests
    {
        [TestMethod]
        public void GivenEmptyArray_ThenReturnCorrectLength()
        {
            var students = new string[0];
            var students1 = Array.Empty<string>();

            Assert.AreEqual(0, students.Length);
            Assert.AreEqual(0, students1.Length);
        }

        [TestMethod]
        public void GivenArrayOfFixedLength_ThenReturnCorrectLength()
        {
            var students = new string[2];

            Assert.AreEqual(2, students.Length);
        }

        [TestMethod]
        public void GivenArrayValues_ThenCreateArrayOfFixedLength()
        {
            var students = new string[] {"John", "Doe" };
            string[] teachers = { "Peter", "John" };
            var parents = new[] { "Mary", "Martha" };

            Assert.AreEqual(2, students.Length);
            Assert.AreEqual(2, parents.Length);
            Assert.AreEqual(2, teachers.Length);
        }

        [TestMethod]
        public void GivenListValues_ThenConvertToArray()
        {
            var studentList = new List<string> {"John", "Doe" };
            var students = studentList.ToArray();

            Assert.AreEqual(2, students.Length);
        }

        [TestMethod]
        public void GivenLengthAndValues_ThenReturnCorrectLength()
        {
            var students = new string[2] {"John", "Doe"};

            Assert.AreEqual(2, students.Length);
        }
    }
}