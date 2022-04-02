using Microsoft.VisualStudio.TestTools.UnitTesting;
using ActionAndFuncInCsharp;
using ActionAndFuncInCsharp.Fruit;
using System.Collections.Generic;
using System;
using System.Linq;

namespace ActionAndFuncInCsharpUnitTests
{
    [TestClass]
    public class ActionAndFuncInCsharpUnitTests
    {
        [TestMethod]
        public void WhenRunningMain_DelegatesWorkAsExpected()
        {
            // test setup
            var salesA = 150000.00;
            var salesB = 780000.00;
            var expenses = 88000.00;
            var expectedAggregateSales = salesA + salesB;
            var expectedProfit = salesA - expenses;
            var expectedFruitCollection = new List<IFruit>() { new Orange() };

            // run test
            try
            {
                Program.Main();
            }
            catch (Exception e)
            {
                Assert.Fail("Expected no exception, but got: " + e.Message);
            }
            
            // assess results
            Assert.AreEqual(expectedAggregateSales ,Program.aggregator(salesA, salesB));
            CollectionAssert.AllItemsAreInstancesOfType(Program.allCitrusFruits.ToList(), typeof(Orange));
        }
    }
}