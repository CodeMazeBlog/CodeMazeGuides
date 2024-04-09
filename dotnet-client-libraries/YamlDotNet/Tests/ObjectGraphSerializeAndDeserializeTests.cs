using App.Models;
using App.UseCases;
using static System.Environment;

namespace Tests;

public class ObjectGraphSerializeAndDeserializeTests
{
    [Fact]
    public void WhenStoreIsSerialized_ThenYamlIsReturned()
    {
        var store = new Store { Name = "Test Store", Items = [] };
        var expectedYaml = $"Name: Test Store{NewLine}Items: []{NewLine}";
        var actualYaml = ObjectGraphSerializeAndDeserialize.SerializeStore(store);
       
        Assert.Equal(expectedYaml, actualYaml);
    }

    [Fact]
    public void WhenYamlIsDeserialized_ThenStoreIsReturned()
    {
        var yaml = $"Name: Test Store{NewLine}Items: []";
        var expectedStore = new Store { Name = "Test Store", Items = [] };
        var actualStore = ObjectGraphSerializeAndDeserialize.DeserializeStore(yaml);

        Assert.Equal(expectedStore.Name, actualStore.Name);
        Assert.Equal(expectedStore.Items.Count, actualStore.Items.Count);
    }
}