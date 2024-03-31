using App.Models;
using App.UseCases;

namespace Tests;

public class ObjectGraphSerializeAndDeserializeTests
{
    [Fact]
    public void WhenStoreIsSerialized_ThenYamlIsReturned()
    {
        var store = new Store { Name = "Test Store", Items = new List<Item>() };
        var expectedYaml = "Name: Test Store\nItems: []\n";
        var actualYaml = ObjectGraphSerializeAndDeserialize.SerializeStore(store);
       
        Assert.Equal(expectedYaml, actualYaml);
    }

    [Fact]
    public void WhenYamlIsDeserialized_ThenStoreIsReturned()
    {
        var yaml = "Name: Test Store\nItems: []";
        var expectedStore = new Store { Name = "Test Store", Items = new List<Item>() };
        var actualStore = ObjectGraphSerializeAndDeserialize.DeserializeStore(yaml);

        Assert.Equal(expectedStore.Name, actualStore.Name);
        Assert.Equal(expectedStore.Items.Count, actualStore.Items.Count);
    }
}