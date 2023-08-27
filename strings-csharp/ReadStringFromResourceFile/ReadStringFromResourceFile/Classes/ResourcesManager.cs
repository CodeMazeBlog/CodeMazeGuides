using System.Globalization;
using System.Reflection;
using System.Resources;

namespace ReadStringFromResourceFile;

public class ResourcesManager
{
    private Assembly? _assembly;
    private ResourceManager _resources;
    private CultureInfo? _culture;

    public ResourcesManager(string resourceBasePath, Assembly? assembly = null, CultureInfo? cultureInfo = null)
    {
        _assembly = assembly ?? Assembly.GetExecutingAssembly();

        _culture = cultureInfo ?? CultureInfo.CurrentCulture;
        _resources = new ResourceManager(resourceBasePath, _assembly);

        if (_resources is null)
            throw new Exception($"Resource path {resourceBasePath} not found.");
    }

    public string? GetString(string key)
    {
        var resource = GetResource<string>(key);
            
        if (!resource.IsValid)
            return string.Empty;

        return resource.Item;
    }

    public ResourceItem<T> GetResource<T>(string key)
    {
        try
        {
            var obj = _resources.GetObject(key, _culture);

            if (obj is T item)
                return new ResourceItem<T>(item);

            return new ResourceItem<T>($"Resource {key} doesn´t exist!");
        }
        catch (MissingManifestResourceException ex)
        {
            return new ResourceItem<T>("Invalid Resource file!");
        }
    }
}
