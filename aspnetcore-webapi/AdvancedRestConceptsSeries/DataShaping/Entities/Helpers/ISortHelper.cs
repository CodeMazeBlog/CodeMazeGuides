using System.Linq;

namespace Entities.Helpers;

public interface ISortHelper<T>
{
    IQueryable<T> ApplySort(IQueryable<T> entities, string? orderByQueryString);
}
