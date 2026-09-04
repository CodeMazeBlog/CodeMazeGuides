using System.Collections.Generic;

namespace Entities.Models;

public class LinkCollectionWrapper<T> : LinkResourceBase
{
    public List<T> Value { get; set; } = [];

    public LinkCollectionWrapper()
    {
    }

    public LinkCollectionWrapper(List<T> value)
    {
        Value = value;
    }
}
