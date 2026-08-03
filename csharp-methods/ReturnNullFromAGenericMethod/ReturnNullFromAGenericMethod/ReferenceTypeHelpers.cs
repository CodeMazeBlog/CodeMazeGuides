using System.Collections;
using System.Linq;

namespace ReturnNullFromAGenericMethod
{
    public class ReferenceTypeHelpers
    {
        public static T? FindItem<T>(List<T> items, string id) where T : class
        {
            return null;
        }
    }
}