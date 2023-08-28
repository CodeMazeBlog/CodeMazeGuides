using System.Globalization;
using System.Reflection;
using System.Resources;

namespace ReadStringFromResourceFile;

public class ResourcesManager
{
    private readonly ResourceManager _resources;
    private readonly CultureInfo? _culture;
    private readonly bool _isValid;

    public ResourcesManager(string resourceBasePath, Assembly? assembly = null, CultureInfo? cultureInfo = null)
    {
        _culture = cultureInfo ?? CultureInfo.CurrentCulture;

        _resources = new ResourceManager(resourceBasePath, assembly ?? Assembly.GetExecutingAssembly());

        try
        {
            using (var rs = _resources.GetResourceSet(_culture, true, true))
                _isValid = rs != null;

            _resources.ReleaseAllResources();
        }
        catch (MissingManifestResourceException)
        {
            _isValid = false;
            return;
        }
    }


    public bool IsValid => _isValid;

    public string? GetString(string key)
    {
        var resource = GetResource<string>(key);
        
        return resource.IsValid ? resource.Item : string.Empty;
    }

    public ResourceItem<T> GetResource<T>(string key)
    {
        if (!IsValid)
            return new ResourceItem<T>("Invalid Resource file!");

        try
        {
            var obj = _resources.GetObject(key, _culture);

            if (obj is T item)
                return new ResourceItem<T>(item);

            return new ResourceItem<T>($"Resource {key} doesn´t exist!");
        }
        catch (MissingManifestResourceException)
        {
            return new ResourceItem<T>("Invalid Resource file!");
        }
    }
}
