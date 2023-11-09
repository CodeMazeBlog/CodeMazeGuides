using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace SliceArrayTests
{
    [TestClass]
    public class SliceArrayTests
    {
        [TestMethod]
        public void WhenUsingLINQ_ThenArrayIsSliced()
        {
            var posts = new string[] { "post1", "post2", "post3", "post4", "post5", "post6", "post7", "post8", "post9", "post10" };
            
            var slicedPosts = posts.Skip(0).Take(5);
            
            Assert.AreEqual(5, slicedPosts.Count());
        }

        [TestMethod]
        public void WhenUsingCopy_ThenArrayIsSliced()
        {
            var posts = new string[] { "post1", "post2", "post3", "post4", "post5", "post6", "post7", "post8", "post9", "post10" };
            
            var slicedPosts = new string[5];
            Array.Copy(posts, 0, slicedPosts, 0, 5);
            
            Assert.AreEqual(5, slicedPosts.Count());
        }

        [TestMethod]
        public void WhenUsingArraySegment_ThenArrayIsSliced()
        {
            var data = new Tuple<int, bool>[] { new(20, true), new(50, true), new(35, false), new(55, true), new(16, false) };
            
            var trainingData = new ArraySegment<Tuple<int, bool>>(data, 0, 3);
            var testingData = new ArraySegment<Tuple<int, bool>>(data, 3, 2);
            
            Assert.AreEqual(3, trainingData.Count());
            Assert.AreEqual(2, testingData.Count());
        }

        [TestMethod]
        public void WhenUsingArraySegmentSlice_ThenArrayIsSliced()
        {
            var data = new Tuple<int, bool>[] { new(20, true), new(50, true), new(35, false), new(55, true), new(16, false) };

            var arraySegment = new ArraySegment<Tuple<int, bool>>(data);
            var trainingData = arraySegment.Slice(0, 3);
            var testingData = arraySegment.Slice(3, 2);

            Assert.AreEqual(3, trainingData.Count());
            Assert.AreEqual(2, testingData.Count());
        }

        [TestMethod]
        public void WhenUsingReadOnlySpan_ThenArrayIsSliced()
        {
            var data = new Tuple<int, bool>[] { new(20, true), new(50, true), new(35, false), new(55, true), new(16, false) };
            
            var trainingData = new ReadOnlySpan<Tuple<int, bool>>(data, 0, 3);
            var testingData = new ReadOnlySpan<Tuple<int, bool>>(data, 3, 2);

            Assert.AreEqual(3, trainingData.Length);
            Assert.AreEqual(2, testingData.Length);
        }

        [TestMethod]
        public void WhenUsingRangeOperator_ThenArrayIsSliced()
        {
            var array = new int[] { 1, 2, 3, 4, 5 };
            
            var slice1 = array[2..]; 
            var slice2 = array[..3];
            var slice3 = array[1..3]; 
            var slice4 = array[..];
            
            Assert.AreEqual(3, slice1.Length);
            Assert.AreEqual(3, slice2.Length);
            Assert.AreEqual(2, slice3.Length);
            Assert.AreEqual(5, slice4.Length);
        }
    }
}
