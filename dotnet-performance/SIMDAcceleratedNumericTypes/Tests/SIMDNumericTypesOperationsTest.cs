using SIMDAcceleratedNumericTypes;
using System.Numerics;

namespace Tests;

public class SIMDNumericTypesOperationsTest
{
    [Fact]
    public void WhenGetDotProductOfTwoVectorsIsCalled_ThenReturnsCorrectResult()
    {
        float expected = 32f;

        var result = SIMDNumericTypesOperations.GetDotProductOfTwoVectors();

        Assert.Equal(expected, result);
    }

    [Fact]
    public void WhenCreateAndMultiplyTwoMatricesWithoutSIMDIsCalled_ThenReturnsCorrectResult()
    {
        float[,] expected = {
            { 90f, 100f, 110f, 120f },
            { 202f, 228f, 254f, 280f },
            { 314f, 356f, 398f, 440f },
            { 426f, 484f, 542f, 600f }
        };

        var result = SIMDNumericTypesOperations.CreateAndMultiplyTwoMatricesWithoutSIMD();

        Assert.Equal(expected, result);
    }

    [Fact]
    public void WhenCreateAndMultiplyTwoMatricesWithSIMDIsCalled_ThenReturnsCorrectResult()
    {
        var expected = new Matrix4x4(
            90f, 100f, 110f, 120f,
            202f, 228f, 254f, 280f,
            314f, 356f, 398f, 440f,
            426f, 484f, 542f, 600f);

        var result = SIMDNumericTypesOperations.CreateAndMultiplyTwoMatricesWithSIMD();

        Assert.Equal(expected, result);
    }
}