using YamlDotNet.RepresentationModel;

namespace Shared;
public static class Helper
{
    public static int GetKafkaBrokerPort(string filePath)
    {
        using var input = new StreamReader(Path.Combine(filePath, @"docker-compose.yml"));
        var yaml = new YamlStream();
        yaml.Load(input);

        var root = (YamlMappingNode)yaml.Documents[0].RootNode;
        var services = (YamlMappingNode)root.Children[new YamlScalarNode("services")];
        var broker = (YamlMappingNode)services.Children[new YamlScalarNode("broker")];

        var ports = (YamlSequenceNode)broker.Children[new YamlScalarNode("ports")];
        var portMapping = (YamlScalarNode)ports.Children.First();

        return int.Parse(portMapping.Value!.Split(":")[0]);
    }
}