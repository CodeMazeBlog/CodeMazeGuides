namespace Tests;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScopedKeyword;

[TestClass]
public class FastStoreUnitTest
{
    [TestMethod]
    public void WhenConstructing_ThenLengthIsThree()
    {
        var store = new FastStore<int>();
        Assert.AreEqual(store.Length, 3);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void WhenCloning_ThenThrowsAnExceptionIfLengthIsNotThree()
    {
        var store = new FastStore<int>();
        Span<int> ints = stackalloc int[2] { 1, 2 };

        store.Clone(ints);
    }
}