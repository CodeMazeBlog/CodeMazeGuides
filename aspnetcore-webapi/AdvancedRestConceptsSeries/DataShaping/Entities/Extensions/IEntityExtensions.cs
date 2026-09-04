using System;

namespace Entities.Extensions;

public static class IEntityExtensions
{
    public static bool IsObjectNull(this IEntity? entity) => entity is null;

    public static bool IsEmptyObject(this IEntity entity) => entity.Id.Equals(Guid.Empty);
}
