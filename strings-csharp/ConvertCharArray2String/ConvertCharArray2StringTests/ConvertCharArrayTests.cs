using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConvertCharArray2StringTests;

[TestClass]
public class ConvertCharArrayTests
{
    private readonly char[] _charArray = ['c', 'o', 'd', 'e', ' ', 'm', 'a', 'z', 'e'];

    [TestMethod]
    public void GivenCharArray_WhenConvertedByConstructor_ThenReturnString()
    {
        var convertedToString = new string(_charArray);

        Assert.AreEqual("code maze", convertedToString);
    }

    [TestMethod]
    public void GivenCharArray_WhenConvertedByJoin_ThenReturnString()
    {
        var joinedToString = string.Join("", _charArray);

        Assert.AreEqual("code maze", joinedToString);
    }

    [TestMethod]
    public void GivenCharArray_WhenConvertedByConcat_ThenReturnString()
    {
        var concatedToString = string.Concat(_charArray);

        Assert.AreEqual("code maze", concatedToString);
    }

    [TestMethod]
    public void GivenCharArray_WhenConvertedByConstructorWithRange_ThenReturnPartOfString()
    {
        var partOfArray = new string(_charArray, 0, 4);

        Assert.AreEqual("code", partOfArray);
    }

    [TestMethod]
    public void GivenSingleChar_WhenConvertedByToString_ThenReturnString()
    {
        char letter = 'c';

        var fromChar = letter.ToString();

        Assert.AreEqual("c", fromChar);
    }

    [TestMethod]
    public void GivenCharArray_WhenJoinedWithSeparator_ThenReturnSeparatedString()
    {
        var withDashes = string.Join("-", _charArray);

        Assert.AreEqual("c-o-d-e- -m-a-z-e", withDashes);
    }

    [TestMethod]
    public void GivenNullCharArray_WhenConvertedByConstructor_ThenReturnEmptyString()
    {
        char[]? nothing = null;

        var convertedToString = new string(nothing);

        Assert.AreEqual(string.Empty, convertedToString);
    }

    [TestMethod]
    public void GivenNullCharArray_WhenConvertedByConcatOrJoin_ThenThrowArgumentNullException()
    {
        char[]? nothing = null;

        Assert.ThrowsExactly<ArgumentNullException>(() => string.Concat(nothing!));
        Assert.ThrowsExactly<ArgumentNullException>(() => string.Join("", nothing!));
    }
}
