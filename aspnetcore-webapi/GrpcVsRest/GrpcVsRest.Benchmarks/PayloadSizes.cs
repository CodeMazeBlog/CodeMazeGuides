using System.IO.Compression;
using System.Text.Json;
using Google.Protobuf;

namespace GrpcVsRest.Benchmarks;

public static class PayloadSizes
{
    public static void Print()
    {
        Console.WriteLine($"{"Shape",-32}{"JSON",8}{"JSON gzip",11}{"Protobuf",10}{"Proto gzip",12}");

        foreach (var shape in Shapes.All())
        {
            var json = JsonSerializer.SerializeToUtf8Bytes(shape.Dto, shape.Dto.GetType(), Shapes.JsonOptions);
            var protobuf = shape.Message.ToByteArray();

            Console.WriteLine($"{shape.Name,-32}{json.Length,8:N0}{Gzip(json),11:N0}" +
                $"{protobuf.Length,10:N0}{Gzip(protobuf),12:N0}");
        }
    }

    private static int Gzip(byte[] bytes)
    {
        using var output = new MemoryStream();
        using (var gzip = new GZipStream(output, CompressionLevel.Fastest, leaveOpen: true))
        {
            gzip.Write(bytes);
        }

        return (int)output.Length;
    }
}
