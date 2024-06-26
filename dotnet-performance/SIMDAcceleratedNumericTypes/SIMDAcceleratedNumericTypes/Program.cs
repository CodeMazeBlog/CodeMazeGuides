using BenchmarkDotNet.Running;
using SIMDAcceleratedNumericTypes;
using System.Numerics;

var vector2 = new Vector2(1f, 2f);
var vector3 = new Vector3(4f, 5f, 6f);
var vector4 = new Vector4(7f, 8f, 9f, 10f);

var intVector = new Vector<int>(new Span<int>([1, 2, 3, 4, 5, 6, 7, 8]));

var matrix1 = new Matrix3x2(
        1f, 2f,
        5f, 6f,
        9f, 10f);

var matrix2 = new Matrix4x4(

        1f, 2f, 3f, 4f,
        5f, 6f, 7f, 8f,
        9f, 10f, 11f, 12f,
        13f, 14f, 15f, 16f);

var matrix3 = Matrix4x4.Transpose(matrix2);
var matrixMultResult = Matrix4x4.Multiply(matrix2, matrix3);

BenchmarkRunner.Run<SIMDNumericTypesBenchmark>();