using System.Reflection;

namespace GetListOfProperties
{
    public class PropertiesRetriever
    {
        public PropertyInfo[] RetrieveProperties(object obj)
        {
            var type = obj.GetType();
            type.GetProperties();

            return type.GetProperties();
        }

        public PropertyInfo[] RetrievePropertiesWithFilter(object obj, BindingFlags binding)
        {
            var type = obj.GetType();
            type.GetProperties();

            return type.GetProperties(binding);
        }

        public PropertyInfo[] RetrieveParentClassPropertiesWithFilter(object obj, BindingFlags binding)
        {
            var type = obj.GetType();
            type.GetProperties();

            return type.BaseType?.GetProperties(binding);
        }

        public void PrintProperties(PropertyInfo[] properties)
        {
            foreach (var item in properties)
            {
                Console.WriteLine($" * {item.Name}");
            }

            Console.WriteLine("--");
            Console.WriteLine();
        }
    }
}
