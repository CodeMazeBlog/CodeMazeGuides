using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ConvertStringAndIntToEnumTests;

[TestClass]
public class ConvertStringAndIntToEnumTests
{
    [TestMethod]
    public void GivenValidEnumAsString_WhenConvertingToEnum_ThenCorrectlyConverted()
    {
        var inputString = "Sunday";
        var mixedCaseInputString = "SaTurDaY";

        var weekDay = Enum.Parse<WeekDay>(inputString);
        var caseInsensitiveWeekDay = Enum.Parse<WeekDay>(mixedCaseInputString, true);

        Assert.AreEqual(WeekDay.Sunday, weekDay);
        Assert.AreEqual(WeekDay.Saturday, caseInsensitiveWeekDay);
    }

    [TestMethod]
    public void GivenInvalidEnumAsString_WhenConvertingToEnum_ThenFails()
    {
        var inputString = "Today";

        var isEnumParsed = Enum.TryParse(inputString, true, out WeekDay weekDay);

        Assert.IsFalse(isEnumParsed);
    }

    [TestMethod]
    public void GivenValidEnumAsStringInteger_WhenConvertingToEnum_ThenCorrectlyConverted()
    {
        var inputString = "0";

        var isEnumParsed = Enum.TryParse(inputString, true, out WeekDay weekDay);

        Assert.IsTrue(isEnumParsed);
        Assert.AreEqual(WeekDay.Monday, weekDay);
    }

    [TestMethod]
    public void GivenNumericStringThatIsNotAMember_WhenConvertingToEnum_ThenParsesIntoAnUndefinedValue()
    {
        var inputString = "42";

        var isEnumParsed = Enum.TryParse<WeekDay>(inputString, out var weekDay);

        Assert.IsTrue(isEnumParsed);
        Assert.IsFalse(Enum.IsDefined(weekDay));
        Assert.AreEqual("42", weekDay.ToString());
    }

    [TestMethod]
    public void GivenValidEnumAsInteger_WhenConvertingToEnum_ThenCorrectlyConverted()
    {
        var inputInt = 2;

        var isEnumParsed = Enum.IsDefined((WeekDay)inputInt);

        Assert.IsTrue(isEnumParsed);
        WeekDay weekDay = (WeekDay)inputInt;
        Assert.AreEqual(WeekDay.Wednesday, weekDay);
    }

    [TestMethod]
    public void GivenInvalidEnumAsInteger_WhenConvertingToEnum_ThenFails()
    {
        var inputInt = 9;

        var isEnumParsed = Enum.IsDefined((WeekDay)inputInt);

        Assert.IsFalse(isEnumParsed);
    }

    [TestMethod]
    public void GivenValidFlagsEnumAsInteger_WhenConvertingToEnum_ThenCorrectlyConverted()
    {
        var inputInt = 3;
        var parsedEnum = (UserType)inputInt;

        var isEnumParsed = Enum.IsDefined(parsedEnum) || parsedEnum.ToString().Contains(",");

        Assert.IsTrue(isEnumParsed);
        Assert.AreEqual(UserType.Customer | UserType.Driver, parsedEnum);
    }

    [TestMethod]
    public void GivenInvalidFlagsEnumAsInteger_WhenConvertingToEnum_ThenFails()
    {
        var inputInt = 8;
        var parsedEnum = (UserType)inputInt;

        var isEnumParsed = Enum.IsDefined(parsedEnum) || parsedEnum.ToString().Contains(",");

        Assert.IsFalse(isEnumParsed);
    }

    [TestMethod]
    public void GivenFlagsEnumValues_WhenCheckingAgainstTheDeclaredFlagsMask_ThenOnlyDeclaredCombinationsAreValid()
    {
        var allFlags = (UserType)0;

        foreach (var flag in Enum.GetValues<UserType>())
        {
            allFlags |= flag;
        }

        Assert.AreEqual((UserType)7, allFlags);

        for (var inputInt = 0; inputInt <= 7; inputInt++)
        {
            var parsedEnum = (UserType)inputInt;

            Assert.IsTrue((parsedEnum & ~allFlags) == 0, $"{inputInt} should be a valid combination");
        }

        var invalidEnum = (UserType)8;

        Assert.IsFalse((invalidEnum & ~allFlags) == 0);
    }
}
