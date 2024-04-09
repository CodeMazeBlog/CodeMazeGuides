using App.Models;
using App.UseCases;
using static System.Environment;

namespace Tests;

public class BasicSerializeAndDeserializeTests
{
    [Fact]
    public void WhenProductIsSerialized_ThenYamlIsReturned()
    {
        var product = new Product { Id = 1, Name = "Test", Price = 10.0m };
        var expectedYaml = $"Id: 1{NewLine}Name: Test{NewLine}Price: 10.0{NewLine}";
        var actualYaml = BasicSerializeAndDeserialize.SerializeProduct(product);

        Assert.Equal(expectedYaml, actualYaml);
    }

    [Fact]
    public void WhenYamlIsDeserialized_ThenProductIsReturned()
    {
        var yaml = $"Id: 1{NewLine}Name: Test{NewLine}Price: 10.0";
        var expectedProduct = new Product { Id = 1, Name = "Test", Price = 10.0m };
        var actualProduct = BasicSerializeAndDeserialize.DeserializeProduct(yaml);

        Assert.Equal(expectedProduct.Id, actualProduct.Id);
        Assert.Equal(expectedProduct.Name, actualProduct.Name);
        Assert.Equal(expectedProduct.Price, actualProduct.Price);
    }
}
