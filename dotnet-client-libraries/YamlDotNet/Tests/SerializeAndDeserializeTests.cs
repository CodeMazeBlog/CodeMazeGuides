using App.Models;
using App.UseCases;

namespace Tests;

public class SerializeAndDeserializeTests
{
    [Fact]
    public void WhenProductIsSerialized_ThenYamlIsReturned()
    {
        var product = new Product { Id = 1, Name = "Test", Price = 10.0m };
        var expectedYaml = $"Id: 1{Environment.NewLine}Name: Test{Environment.NewLine}Price: 10.0{Environment.NewLine}";
        var actualYaml = SerializeAndDeserialize.Serialize(product);

        Assert.Equal(expectedYaml, actualYaml);
    }

    [Fact]
    public void WhenYamlIsDeserialized_ThenProductIsReturned()
    {
        var yaml = $"Id: 1{Environment.NewLine}Name: Test{Environment.NewLine}Price: 10.0";
        var expectedProduct = new Product { Id = 1, Name = "Test", Price = 10.0m };
        var actualProduct = SerializeAndDeserialize.Deserialize<Product>(yaml);

        Assert.Equal(expectedProduct.Id, actualProduct.Id);
        Assert.Equal(expectedProduct.Name, actualProduct.Name);
        Assert.Equal(expectedProduct.Price, actualProduct.Price);
    }

    [Fact]
    public void WhenStoreIsSerialized_ThenYamlIsReturned()
    {
        var store = new Store { Name = "Test Store", Items = [] };
        var expectedYaml = $"Name: Test Store{Environment.NewLine}Items: []{Environment.NewLine}";
        var actualYaml = SerializeAndDeserialize.Serialize(store);

        Assert.Equal(expectedYaml, actualYaml);
    }

    [Fact]
    public void WhenYamlIsDeserialized_ThenStoreIsReturned()
    {
        var yaml = $"Name: Test Store{Environment.NewLine}Items: []";
        var expectedStore = new Store { Name = "Test Store", Items = [] };
        var actualStore = SerializeAndDeserialize.Deserialize<Store>(yaml);

        Assert.Equal(expectedStore.Name, actualStore.Name);
        Assert.Equal(expectedStore.Items.Count, actualStore.Items.Count);
    }
}