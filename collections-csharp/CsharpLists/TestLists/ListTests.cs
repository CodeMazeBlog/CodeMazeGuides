using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsharpLists;
using System.Collections.Generic;
using System.Linq;

namespace TestLists
{
    [TestClass]
    public class ListTests
    {
        [TestMethod]
        public void GivenEmptyList_AddItems()
        {
            var operations = new ListOperations();
            var otherCountries = new List<string>() { "Russia", "Bulgaria", "South Africa" };

            var countries = operations.AddElements();
           
            Assert.AreEqual(countries.Count, otherCountries.Count);
        }

        [TestMethod]
        public void GivenArray_AddItemsToList()
        {
            var operations = new ListOperations();
            var otherCountries = new string[3] { "Russia", "Bulgaria", "South Africa" };

            var countries = operations.AddElements();
            countries.AddRange(otherCountries);

            Assert.AreEqual(6, countries.Count);
        }

        [TestMethod]
        public void GivenList_ReadListItem()
        {
            var otherCountries = new List<string>() { "Russia", "Bulgaria", "South Africa" };

            var result = from s in otherCountries
                         where s.Equals("South Africa")
                         select s;
            foreach (var item in otherCountries) 
            {
                if (item.Equals("South Africa"))
                    Assert.IsTrue(item.Equals("South Africa"));
            }

            Assert.AreEqual("South Africa", otherCountries[2]);
            Assert.AreEqual("South Africa", result.First());
        }

        [TestMethod]
        public void GivenNonEmptyList_InsertListItem()
        {
            var operations = new ListOperations();
            var otherCountries = new List<string>() { "Russia", "Bulgaria", "South Africa" };

            var countries = operations.AddElements();
            countries.Insert(1, "Canada");
            countries.InsertRange(countries.Count - 1, otherCountries);

            Assert.AreEqual("Canada", countries[1]);
            Assert.AreEqual(7, countries.Count);
        }

        [TestMethod]
        public void GivenNonEmptyList_RemoveListItem()
        {
            var otherCountries = new List<string>() { "Russia", "Bulgaria", "South Africa", "Mexico", "USA" };

            otherCountries.Remove("Russia");

            Assert.AreEqual(4, otherCountries.Count);
            CollectionAssert.DoesNotContain(otherCountries, "Russia");
        }

        [TestMethod]
        public void GivenNonEmptyList_RemoveAtItemPosition()
        {
            var otherCountries = new List<string>() { "Russia", "Bulgaria", "South Africa", "Mexico", "USA" };

            otherCountries.RemoveAt(0);

            Assert.AreEqual(4, otherCountries.Count);
            CollectionAssert.DoesNotContain(otherCountries, "Russia");
        }

        [TestMethod]
        public void GivenNonEmptyList_ClearList()
        {
            var otherCountries = new List<string>() { "Russia", "Bulgaria", "South Africa", "Mexico", "USA" };

            otherCountries.Clear();

            Assert.AreEqual(0, otherCountries.Count);
        }

        [TestMethod]
        public void GivenNonEmptyList_RemoveRangeListItems()
        {
            var otherCountries = new List<string>() { "Russia", "Bulgaria", "South Africa", "Mexico", "USA" };

            otherCountries.RemoveRange(0, 2);

            Assert.AreEqual(3, otherCountries.Count);
            CollectionAssert.DoesNotContain(otherCountries, "Russia");
            CollectionAssert.DoesNotContain(otherCountries, "Bulgaria");
        }

        [TestMethod]
        public void GivenNonEmptyList_CheckContainsListItem()
        {
            var otherCountries = new List<string>() { "Russia", "Bulgaria", "South Africa" };

            CollectionAssert.DoesNotContain(otherCountries, "Malawi");
            CollectionAssert.DoesNotContain(otherCountries, "France");
            CollectionAssert.Contains(otherCountries, "Russia");
            CollectionAssert.Contains(otherCountries, "South Africa");
        }
    }
}