using Entities.Models;
using System.Collections.Generic;

namespace Entities.Helpers;

public interface IDataShaper<T>
{
    IEnumerable<Entity> ShapeData(IEnumerable<T> entities, string? fieldsString);
    Entity ShapeData(T entity, string? fieldsString);
}
