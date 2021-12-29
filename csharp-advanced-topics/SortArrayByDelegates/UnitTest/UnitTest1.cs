using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortArrayByDelegates;
using System;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Random rnd = new Random();
            List<int> arr = new List<int>();
            for (int i = 0; i < 100; i++)
            {
                arr.Add(rnd.Next(0, 1000));
            }
            var dataset1 = new Program.DataSet<int>(arr);
            dataset1.Sort_Method = Program.arr_sort;
            dataset1.Sort();
            for (int i = 0; i < dataset1.arr.Count - 1; i++)
            {
                Assert.IsTrue(dataset1.arr[i] <= dataset1.arr[i + 1], String.Format("item {0} > {1}", i, i + 1));
            }
        }
        [TestMethod]
        public void TestMethod2()
        {
            Random rnd = new Random();
            List<Program.Entity> arr = new List<Program.Entity>();
            for (int i = 0; i < 100; i++)
            {
                var entity = new Program.Entity();
                entity.rowId = rnd.Next(0, 1000);
                arr.Add(entity);
            }
            var dataset2 = new Program.DataSet<Program.Entity>(arr);
            dataset2.Sort_Method = Program.arr_sort;
            dataset2.Sort();
            for (int i = 0; i < dataset2.arr.Count - 1; i++)
            {
                Assert.IsTrue(dataset2.arr[i].rowId <= dataset2.arr[i + 1].rowId, String.Format("the rowId of the item at {0} > the item at {1}", i, i + 1));
            }
        }
    }
}
