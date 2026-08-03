using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;

namespace ParamsKeyword
{
    [TestFixture]
    public class CallParamsMethodUnitTest
    {
        [Test]
        public void WhenCommaDelimitedListOfArgs_ThenReturnsValidResult()
        {
            //capture the console output
            using var writer = new StringWriter();
            Console.SetOut(writer);

            var shoppingList = new ShoppingList();
            shoppingList.Add("Bananas", "Grapes", "Ham", "Cheese");
            shoppingList.Add("Headphones");

            var expectedResult = new string[] {
                "Added: Bananas",
                "Added: Grapes",
                "Added: Ham",
                "Added: Cheese",
                "Added: Headphones",
            };

            Assert.AreEqual(expectedResult, writer.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries));
        }

        [Test]
        public void WhenCollectionArgument_ThenReturnsValidResult()
        {
            //capture the console output
            using var writer = new StringWriter();
            Console.SetOut(writer);

            var shoppingList = new ShoppingList();
            var groceries = new [] { "Bananas", "Grapes", "Ham", "Cheese" };
            shoppingList.Add(groceries);

            var expectedResult = new string[] {
                "Added: Bananas",
                "Added: Grapes",
                "Added: Ham",
                "Added: Cheese"
            };

            Assert.AreEqual(expectedResult, writer.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries));
        }

        [Test]
        public void WhenNoArguments_ThenReturnsValidResult()
        {
            //capture the console output
            using var writer = new StringWriter();
            Console.SetOut(writer);

            var shoppingList = new ShoppingList();
            shoppingList.Add();

            Assert.AreEqual(string.Empty, writer.ToString());
        }

        [Test]
        public void WhenNullArgument_ThenThrowsAnException()
        {
            //capture the console output
            using var writer = new StringWriter();
            Console.SetOut(writer);

            var shoppingList = new ShoppingList();
            string[]? groceries = default;

            #pragma warning disable CS8604 // Possible null reference argument.
            Assert.Throws<NullReferenceException>(()=>shoppingList.Add(groceries));
            #pragma warning restore CS8604 // Possible null reference argument.
        }
    }
}