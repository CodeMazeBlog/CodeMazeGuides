using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace SliceArrayTests;

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
    public void WhenUsingAsSpan_ThenArrayIsSlicedWithoutCopying()
    {
        var data = new Tuple<int, bool>[] { new(20, true), new(50, true), new(35, false), new(55, true), new(16, false) };

        var trainingData = data.AsSpan(0, 3);
        var testingData = data.AsSpan(3);
        trainingData[0] = new(40, false);

        Assert.AreEqual(3, trainingData.Length);
        Assert.AreEqual(2, testingData.Length);
        Assert.AreEqual(new Tuple<int, bool>(40, false), data[0]);
    }

    [TestMethod]
    public void WhenUsingSpanSlice_ThenSpanIsSliced()
    {
        var data = new Tuple<int, bool>[] { new(20, true), new(50, true), new(35, false), new(55, true), new(16, false) };

        var trainingData = data.AsSpan(0, 3);
        var firstTwo = trainingData.Slice(0, 2);

        Assert.AreEqual(2, firstTwo.Length);
        Assert.AreEqual(data[1], firstTwo[1]);
    }

    [TestMethod]
    public void WhenUsingIndexFromEnd_ThenLastElementsAreSliced()
    {
        var data = new Tuple<int, bool>[] { new(20, true), new(50, true), new(35, false), new(55, true), new(16, false) };

        var lastTwo = data.AsSpan()[^2..];

        Assert.AreEqual(2, lastTwo.Length);
        Assert.AreEqual(data[3], lastTwo[0]);
        Assert.AreEqual(data[4], lastTwo[1]);
    }

    [TestMethod]
    public void WhenUsingRangeOperator_ThenArrayIsSliced()
    {
        var array = new int[] { 1, 2, 3, 4, 5 };

        var slice1 = array[2..];
        var slice2 = array[..2];
        var slice3 = array[1..3];
        var slice4 = array[..];

        Assert.AreEqual(3, slice1.Length);
        Assert.AreEqual(2, slice2.Length);
        Assert.AreEqual(2, slice3.Length);
        Assert.AreEqual(5, slice4.Length);
    }

    [TestMethod]
    public void WhenUsingReversedRange_ThenArgumentOutOfRangeExceptionIsThrown()
    {
        var array = new int[] { 1, 2, 3, 4, 5 };

        Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => array[3..1]);
    }

    [TestMethod]
    public void WhenUsingRangeOperatorOnList_ThenListIsCopied()
    {
        var list = new List<int> { 10, 20, 30, 40, 50 };

        var slice = list[1..3];
        slice[0] = 777;

        CollectionAssert.AreEqual(new List<int> { 777, 30 }, slice);
        Assert.AreEqual(20, list[1]);
    }

    [TestMethod]
    public void WhenUsingGetRange_ThenListIsCopied()
    {
        var list = new List<int> { 10, 20, 30, 40, 50 };

        var slice = list.GetRange(1, 2);
        slice[0] = 777;

        Assert.AreEqual(2, slice.Count);
        Assert.AreEqual(20, list[1]);
    }

    [TestMethod]
    public void WhenUsingCollectionsMarshalAsSpan_ThenWritesReachTheList()
    {
        var list = new List<int> { 10, 20, 30, 40, 50 };

        var view = CollectionsMarshal.AsSpan(list);
        view[1] = 777;

        Assert.AreEqual(5, view.Length);
        Assert.AreEqual(777, list[1]);
    }

    [TestMethod]
    public void WhenUsingRangeOperatorOnString_ThenSubstringIsReturned()
    {
        var text = "code-maze";

        var slice = text[5..];

        Assert.AreEqual("maze", slice);
        Assert.AreEqual(text.Substring(5), slice);
    }

    [TestMethod]
    public void WhenUsingAsSpanOnString_ThenCharactersAreSlicedWithoutCopying()
    {
        var text = "code-maze";

        var slice = text.AsSpan(5);

        Assert.AreEqual("maze", slice.ToString());
    }
}
