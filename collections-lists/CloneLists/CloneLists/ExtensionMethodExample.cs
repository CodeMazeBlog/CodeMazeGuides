using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloneLists
{
    public class ExtensionMethodExample
    {
        public List<Restaurant>? clonedRestaurantList;
        public void RunExtensionMethodExample(List<Restaurant> rlist)
        {  
            clonedRestaurantList = rlist.Clone().ToList<Restaurant>();
        }
    }

    public static class Extensions 
    {      
        public static IEnumerable<T> Clone<T>(this IEnumerable<T> collection) where T : ICloneable 
        { 
            return collection.Select(item => (T)item.Clone()); 
        }
    }
}
