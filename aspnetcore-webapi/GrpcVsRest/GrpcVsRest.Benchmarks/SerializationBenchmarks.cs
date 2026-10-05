using System.Text.Json;
using System.Text.Json.Serialization;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using Google.Protobuf;
using GrpcVsRest.Server;

namespace GrpcVsRest.Benchmarks;

[JsonSourceGenerationOptions(JsonSerializerDefaults.Web)]
[JsonSerializable(typeof(List<ProductDto>))]
public partial class CatalogJsonContext : JsonSerializerContext;

[MemoryDiagnoser]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[CategoriesColumn]
public class SerializationBenchmarks
{
    private List<ProductDto> _products = [];
    private ProductList _productList = new();
    private byte[] _json = [];
    private byte[] _protobuf = [];

    [GlobalSetup]
    public void Setup()
    {
        (_products, _productList) = Shapes.Catalog();
        _json = JsonSerializer.SerializeToUtf8Bytes(_products, Shapes.JsonOptions);
        _protobuf = _productList.ToByteArray();
    }

    [Benchmark(Baseline = true), BenchmarkCategory("Serialize")]
    public byte[] SerializeJson() => JsonSerializer.SerializeToUtf8Bytes(_products, Shapes.JsonOptions);

    [Benchmark, BenchmarkCategory("Serialize")]
    public byte[] SerializeJsonSourceGen() =>
        JsonSerializer.SerializeToUtf8Bytes(_products, CatalogJsonContext.Default.ListProductDto);

    [Benchmark, BenchmarkCategory("Serialize")]
    public byte[] SerializeProtobuf() => _productList.ToByteArray();

    [Benchmark(Baseline = true), BenchmarkCategory("Deserialize")]
    public List<ProductDto>? DeserializeJson() =>
        JsonSerializer.Deserialize<List<ProductDto>>(_json, Shapes.JsonOptions);

    [Benchmark, BenchmarkCategory("Deserialize")]
    public List<ProductDto>? DeserializeJsonSourceGen() =>
        JsonSerializer.Deserialize(_json, CatalogJsonContext.Default.ListProductDto);

    [Benchmark, BenchmarkCategory("Deserialize")]
    public ProductList DeserializeProtobuf() => ProductList.Parser.ParseFrom(_protobuf);
}
