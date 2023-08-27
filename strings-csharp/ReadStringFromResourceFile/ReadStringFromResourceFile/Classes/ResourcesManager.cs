using System.Globalization;
using System.Reflection;
using System.Resources;

namespace ReadStringFromResourceFile;

public class ResourcesManager
{
    private Assembly? _assembly;
    private ResourceManager _resources;
    private CultureInfo? _culture;

    public ResourcesManager(string resourceFile, Assembly? assembly = null, CultureInfo? cultureInfo = null)
    {
        _assembly = assembly ?? Assembly.GetExecutingAssembly();

        _culture = cultureInfo ?? CultureInfo.CurrentCulture;
        _resources = new ResourceManager(resourceFile, _assembly);

        if (_resources is null)
            throw new Exception($"Resource file {resourceFile} not found.");
    }

    public string? GetString(string key)
    {
        try
        {
            var resource = GetResource<string>(key);
            
            if (!resource.IsValid)
                return string.Empty;

            return resource.Item;
        }
        catch
        {
            return null;
        }
    }

    public ResourceItem<T> GetResource<T>(string key)
    {
        try
        {
            var obj = _resources.GetObject(key, _culture);

            if (obj is T)
                return new ResourceItem<T>((T)obj);
            else
                return new ResourceItem<T>();
        }
        catch
        {
            return new ResourceItem<T>();
        }
    }
}
