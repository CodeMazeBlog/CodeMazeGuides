using System;
using System.Collections.Generic;
using CheckIfNumberIsPowerOf2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests;

[TestClass]
public class PowerOf2VerifierUnitTest
{
    [DataTestMethod]
    [DynamicData(nameof(GetVerifierFunctions), DynamicDataSourceType.Method)]
    public void Given0_WhenCheckIfPowerOf2_ReturnFalse(Func<int, bool> verifier)
    {
        Assert.IsFalse(verifier(0));
    }

    [DataTestMethod]
    [DynamicData(nameof(GetVerifierFunctions), DynamicDataSourceType.Method)]
    public void GivenPowerOf2_WhenCheckIfPowerOf2_ReturnTrue(Func<int, bool> verifier)
    {
        Assert.IsTrue(verifier(1024));
    }

    [DataTestMethod]
    [DynamicData(nameof(GetVerifierFunctions), DynamicDataSourceType.Method)]
    public void GivenNonPowerOf2_WhenCheckIfPowerOf2_ReturnFalse(Func<int, bool> verifier)
    {
        Assert.IsFalse(verifier(1000));
    }

    [DataTestMethod]
    [DynamicData(nameof(GetVerifierFunctions), DynamicDataSourceType.Method)]
    public void GivenMaxInt_WhenCheckIfPowerOf2_ReturnFalse(Func<int, bool> verifier)
    {
        Assert.IsFalse(verifier(int.MaxValue));
    }

    public static IEnumerable<object[]> GetVerifierFunctions()
    {
        yield return new object[] { (Func<int, bool>) PowerOf2Verifier.CheckWithLog };
        yield return new object[] { (Func<int, bool>) PowerOf2Verifier.CheckWithBitMaskV1 };
        yield return new object[] { (Func<int, bool>) PowerOf2Verifier.CheckWithBitMaskV2 };
        yield return new object[] { (Func<int, bool>) PowerOf2Verifier.CheckWithBitMaskV3 };
    }

    [TestMethod]
    public void GivenNonPowerOf2InULong_WhenCheckIfPowerOf2WithLog_ReturnTrue()
    {
        Assert.IsTrue(PowerOf2Verifier.CheckWithLog(9_223_372_036_854_775_809));
    }
}