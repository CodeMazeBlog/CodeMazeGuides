using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Entities.Helpers;

public class DataShaper<T> : IDataShaper<T>
{
    private readonly PropertyInfo[] _properties;

    public DataShaper()
    {
        _properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
    }

    public IEnumerable<ShapedEntity> ShapeData(IEnumerable<T> entities, string? fieldsString)
    {
        var requiredProperties = GetRequiredProperties(fieldsString);

        return entities.Select(entity => FetchDataForEntity(entity, requiredProperties)).ToList();
    }

    public ShapedEntity ShapeData(T entity, string? fieldsString)
    {
        var requiredProperties = GetRequiredProperties(fieldsString);

        return FetchDataForEntity(entity, requiredProperties);
    }

    private IEnumerable<PropertyInfo> GetRequiredProperties(string? fieldsString)
    {
        if (string.IsNullOrWhiteSpace(fieldsString))
            return _properties;

        var requiredProperties = new List<PropertyInfo>();
        var fields = fieldsString.Split(',', StringSplitOptions.RemoveEmptyEntries);

        foreach (var field in fields)
        {
            var property = _properties.FirstOrDefault(pi =>
                pi.Name.Equals(field.Trim(), StringComparison.OrdinalIgnoreCase));

            if (property is null)
                continue;

            requiredProperties.Add(property);
        }

        return requiredProperties;
    }

    private static ShapedEntity FetchDataForEntity(T entity, IEnumerable<PropertyInfo> requiredProperties)
    {
        var shapedObject = new ShapedEntity();

        foreach (var property in requiredProperties)
            shapedObject.Entity.TryAdd(property.Name, property.GetValue(entity)!);

        var idProperty = typeof(T).GetProperty("Id");
        shapedObject.Id = (Guid)idProperty!.GetValue(entity)!;

        return shapedObject;
    }
}
