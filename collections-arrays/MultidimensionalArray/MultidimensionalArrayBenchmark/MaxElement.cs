using BenchmarkDotNet.Attributes;

public class MaxElement
{
    private double[,] elementsMulti = new double[10000, 10000];
    private double[][] elementsJagged = new double[10000][];

    public MaxElement()
    {
        for (int i = 0; i < elementsJagged.Length; i++)
        {
            elementsJagged[i] = new double[10000];
        }

        elementsMulti[elementsMulti.GetLength(0) / 2, elementsMulti.GetLength(1) / 2] = 1;

        int middleArrayIndex = elementsJagged.Length / 2;
        elementsJagged[middleArrayIndex][elementsJagged[middleArrayIndex].Length / 2] = 1;
    }

    [Benchmark(Baseline = true)]
    public void MultidimensionalArray()
    {
        double max = double.MinValue;
        for (int row = 0; row < elementsMulti.GetLength(0); row++)
        {
            for (int col = 0; col < elementsMulti.GetLength(1); col++)
            {
                max = Math.Max(max, elementsMulti[row, col]);
            }
        }
    }

    [Benchmark]
    public void JaggedArray()
    {
        double max = double.MinValue;
        for (int row = 0; row < elementsJagged.Length; row++)
        {
            for (int col = 0; col < elementsJagged[row].Length; col++)
            {
                max = Math.Max(max, elementsJagged[row][col]);
            }
        }
    }
}