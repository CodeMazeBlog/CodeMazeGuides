using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static LINQSortingAndFiltering.Program;

namespace LINQSortingAndFilteringTests
{
    [TestClass]
    public class LINQSortingAndFilteringTest
    {
        [TestMethod]
        public void WhenCallingSorting_thenNoException()
        {
            try
            {
                Sorting();
            }
            catch(Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void WhenCallingFiltering_thenNoException()
        {
            try
            {
                Filtering();
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    }
}