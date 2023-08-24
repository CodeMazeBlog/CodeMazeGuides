using System.Drawing;
using BenchmarkDotNet.Attributes;

public class Convolution
{
    [Benchmark(Baseline = true)]
    public void MultidimensionalKernel()
    {
        var image = (Bitmap)Image.FromFile("example.png");
        var kernel = new double[,] { { 2, 1, 0 }, { 1, 0, -1 }, { 0, -1, -2 } };
        int kernelOffset = 1;
        var destImage = new Bitmap(image.Width, image.Height);

        for (int row = 0; row < image.Height; row++)
        {
            for (int col = 0; col < image.Width; col++)
            {
                var r = 0d;
                var g = 0d;
                var b = 0d;

                for (int kernelRow = 0; kernelRow < kernel.GetLength(0); kernelRow++)
                {
                    int srcRow = row + (kernelRow - kernelOffset);
                    if (srcRow < 0 || srcRow > (image.Height - 1))
                        continue;

                    for (int kernelCol = 0; kernelCol < kernel.GetLength(1); kernelCol++)
                    {
                        int srcCol = col + (kernelCol - kernelOffset);
                        if (srcCol < 0 || srcCol > (image.Width - 1))
                            continue;

                        r += image.GetPixel(srcCol, srcRow).R * kernel[kernelRow, kernelCol];
                        g += image.GetPixel(srcCol, srcRow).G * kernel[kernelRow, kernelCol];
                        b += image.GetPixel(srcCol, srcRow).B * kernel[kernelRow, kernelCol];
                    }
                }

                r /= 3;
                g /= 3;
                b /= 3;

                destImage.SetPixel(
                    col,
                    row,
                    Color.FromArgb(
                        (byte)Math.Round(r),
                        (byte)Math.Round(g),
                        (byte)Math.Round(b)));
            }
        }
    }

    [Benchmark]
    public void JaggedKernel()
    {
        var image = (Bitmap)Image.FromFile("example.png");
        var destImage = new Bitmap(image.Width, image.Height);
        var kernel = new double[][]
        {
            new double[] { 2, 1, 0 },
            new double[] { 1, 0, -1 },
            new double[] { 0, -1, -2 }
        };
        int kernelOffset = 1;

        for (int row = 0; row < image.Height; row++)
        {
            for (int col = 0; col < image.Width; col++)
            {
                var r = 0d;
                var g = 0d;
                var b = 0d;

                for (int kernelRow = 0; kernelRow < kernel.Length; kernelRow++)
                {
                    int srcRow = row + (kernelRow - kernelOffset);
                    if (srcRow < 0 || srcRow > (image.Height - 1))
                        continue;

                    for (int kernelCol = 0; kernelCol < kernel[kernelRow].Length; kernelCol++)
                    {
                        int srcCol = col + (kernelCol - kernelOffset);
                        if (srcCol < 0 || srcCol > (image.Width - 1))
                            continue;

                        r += image.GetPixel(srcCol, srcRow).R * kernel[kernelRow][kernelCol];
                        g += image.GetPixel(srcCol, srcRow).G * kernel[kernelRow][kernelCol];
                        b += image.GetPixel(srcCol, srcRow).B * kernel[kernelRow][kernelCol];
                    }
                }

                r /= 3;
                g /= 3;
                b /= 3;

                destImage.SetPixel(
                    col,
                    row,
                    Color.FromArgb(
                        (byte)Math.Round(r),
                        (byte)Math.Round(g),
                        (byte)Math.Round(b)));
            }
        }
    }
}