using System.Numerics;

namespace SIMDAcceleratedNumericTypes;

public class SIMDNumericTypesOperations
{
    public static float GetDotProductOfTwoVectors()
    {
        var vector1 = new Vector3(1f, 2f, 3f);
        var vector2 = new Vector3(4f, 5f, 6f);

        return Vector3.Dot(vector1, vector2);
    }

    public static Matrix4x4 CreateAndMultiplyTwoMatricesWithSIMD()
    {
        var matrix1 = new Matrix4x4(
                1f, 2f, 3f, 4f,
                5f, 6f, 7f, 8f,
                9f, 10f, 11f, 12f,
                13f, 14f, 15f, 16f);

        var matrix2 = matrix1;

        return Matrix4x4.Multiply(matrix1, matrix2);
    }

    public static float[,] CreateAndMultiplyTwoMatricesWithoutSIMD()
    {
        float[,] matrix1 = 
        {
            { 1f, 2f, 3f, 4f },
            { 5f, 6f, 7f, 8f },
            { 9f, 10f, 11f, 12f },
            { 13f, 14f, 15f, 16f }
        };

        float[,] matrix2 = matrix1;

        float[,] result = new float[4, 4];
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                result[i, j] = 0;
                for (int k = 0; k < 4; k++)
                {
                    result[i, j] += matrix1[i, k] * matrix2[k, j];
                }
            }
        }

        return result;
    }
}