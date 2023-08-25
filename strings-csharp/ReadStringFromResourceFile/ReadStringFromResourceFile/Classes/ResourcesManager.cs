using System.Globalization;
using System.Reflection;
using System.Resources;

namespace ReadStringFromResourceFile;

public class ResourcesManager
{
    private Assembly? assembly;
    private ResourceManager resources;
    private CultureInfo? culture;

    public ResourcesManager(string resourceFile, Assembly? assembly = null, CultureInfo? cultureInfo = null)
    {
        assembly = assembly ?? Assembly.GetExecutingAssembly();

        culture = cultureInfo ?? CultureInfo.CurrentCulture;
        resources = new ResourceManager(resourceFile, assembly);

        if (resources is null)
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
            var obj = resources.GetObject(key, culture);

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
