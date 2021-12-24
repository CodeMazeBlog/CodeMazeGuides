using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Collections.Generic;
using ActionAndFuncDelegatesInCsharp;

namespace Tests
{
	delegate string PrintMessage(string text);
	delegate T Print<T>(T param1);

	[TestClass]
	public class Tests
	{
        
        Person TestPerson = new Person { firstName = "Arlene", lastName = "Underfoot", age = 19, height = 160, weight = 60 };
        List<Person> TestPeople = new List<Person> {
            new Person { firstName = "A", lastName = "Z", age = 14, height = 130, weight = 60 },
            new Person { firstName = "B", lastName = "Y", age = 19, height = 140, weight = 70 },
            new Person { firstName = "C", lastName = "X", age = 22, height = 150, weight = 65 }
        };

		public static string WriteText(string text) { return $"Text:{text}"; }
		public static string ReverseText(string text) { return Reverse(text); }
		public static void ReverseWriteText(string text) { Console.WriteLine(Reverse(text)); }

		private static string Reverse(string s)
		{
			char[] charArray = s.ToCharArray();
			Array.Reverse(charArray);
			return new string(charArray);
		}

		[TestMethod]
		public void whenIs18PlusIsCalled_MethodReturnsCorrectResult()
		{
			Assert.IsTrue(Program.is18Plus(TestPerson));
		}

		[TestMethod]
		public void whenIsHighBMIIsCalled_MethodReturnsCorrectResult()
		{
			Assert.IsFalse(Program.isHighBMI(TestPerson));
		}

		[TestMethod]
		public void whenOrderFirstNameIsUsed_ExpressionReturnsCorrectlyOrderedResult()
		{
            var actual = TestPeople.OrderBy(Program.orderFirstName).ToList();
			var expected = TestPeople.OrderBy(p => p.firstName).ToList();

			// Ensure that We have the same first and last
			Assert.IsTrue(expected.First().firstName.Equals(actual.First().firstName) &&
				expected.Last().firstName.Equals(actual.Last().firstName));
		}

		[TestMethod]
		public void whenOrderLastNameIsUsed_ExpressionReturnsCorrectlyOrderedResult()
		{
            var actual = TestPeople.OrderBy(Program.orderLastName).ToList();
			var expected = TestPeople.OrderBy(p => p.lastName).ToList();

			// Ensure that We have the same first and last
			Assert.IsTrue(expected.First().lastName.Equals(actual.First().lastName) &&
				expected.Last().lastName.Equals(actual.Last().lastName));
		}

	}
}
