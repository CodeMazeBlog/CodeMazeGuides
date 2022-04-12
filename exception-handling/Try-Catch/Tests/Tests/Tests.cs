using System;
using Try_Catch;
using Xunit;

namespace Tests;

public class Tests
{
    private readonly TryCatchSampleSetup _tryCatchSampleSetup = new TryCatchSampleSetup();

    [Fact]
    public void GivenMultipleCatchSetup_WhenExceptionisRaised_ThenCatchandThrow()
    {
        //Act
        var response = Assert.Throws<IndexOutOfRangeException>(() => _tryCatchSampleSetup.MultipleCatchSetup());

        //Assert
        Assert.NotNull(response);
    }

    [Fact]
    public void GivenNestedCatchSetupSampleOne_WhenExceptionisRaised_ThenThrowDivideByZeroException()
    {
        //Act
        var response = Assert.Throws<DivideByZeroException>(() => _tryCatchSampleSetup.NestedCatchSetup(0));

        //Assert
        Assert.NotNull(response);
    }

    [Fact]
    public void GivenNestedCatchSetupSampleTwo_WhenExceptionisRaised_ThenThrowIndexOutOfRangeException()
    {
        //Act
        var response = Assert.Throws<IndexOutOfRangeException>(() => _tryCatchSampleSetup.NestedCatchSetup(34));

        //Assert
        Assert.NotNull(response);
    }

    [Fact]
    public void GivenGeneralCatchSetup_WhenExceptionisRaised_ThenThrowArgumentException()
    {
        //Act
        var response = Assert.Throws<ArithmeticException>(() => _tryCatchSampleSetup.GeneralCatchSetup(10));

        //Assert
        Assert.NotNull(response);
    }

    [Fact]
    public void GivenGeneralCatchSetup_WhenExceptionisRaised_ThenThrowDivideByZeroException()
    {
        //Act
        var response = Assert.Throws<DivideByZeroException>(() => _tryCatchSampleSetup.GeneralCatchSetup(0));

        //Assert
        Assert.NotNull(response);
    }

    [Fact]
    public void GivenGeneralCatchSetupWithDefaultExceptionParameter_WhenExceptionisRaised_ThenThrowArgumentException()
    {
        //Act
        var response = Assert.Throws<ArithmeticException>(() => _tryCatchSampleSetup.GeneralCatchSetupWithDefaultExceptionParameter(10));

        //Assert
        Assert.NotNull(response);
    }

    [Fact]
    public void GivenGeneralCatchSetupWithDefaultExceptionParameter_WhenExceptionisRaised_ThenThrowDivideByZeroException()
    {
        //Act
        var response = Assert.Throws<DivideByZeroException>(() => _tryCatchSampleSetup.GeneralCatchSetupWithDefaultExceptionParameter(0));

        //Assert
        Assert.NotNull(response);
    }

    [Fact]
    public void GivenExceptionFilterSetup_WhenExceptionisRaised_ThenReturnNoNegativeIndexAllowedMessage()
    {
        //Act
        var response = Assert.Throws<IndexOutOfRangeException>(() => _tryCatchSampleSetup.ExceptionFilterSetup(new int[] { 1},-1));

        //Assert
        Assert.NotNull(response);
        Assert.Contains("index of an array cannot be negative.",response.Message);
    }

    [Fact]
    public void GivenExceptionFilterSetup_WhenExceptionisRaised_ThenReturnIndexOutofRangeMessage()
    {
        //Act
        var response = Assert.Throws<IndexOutOfRangeException>(() => _tryCatchSampleSetup.ExceptionFilterSetup(new int[] { 1 }, 3));

        //Assert
        Assert.NotNull(response);
        Assert.Contains("index cannot be greater than the array size.", response.Message);
    }
}
