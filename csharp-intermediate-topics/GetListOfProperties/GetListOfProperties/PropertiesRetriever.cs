using System.Reflection;

namespace GetListOfProperties
{
    public class PropertiesRetriever
    {
        public PropertyInfo[] RetrieveProperties(object @object)
        {
            var type = @object.GetType();
            type.GetProperties();

            return type.GetProperties();
        }

        public PropertyInfo[] RetrievePropertiesWithFilter(object @object, BindingFlags binding)
        {
            var type = @object.GetType();
            type.GetProperties();

            return type.GetProperties(binding);
        }

        public PropertyInfo[] RetrieveParentClassPropertiesWithFilter(object @object, BindingFlags binding)
        {
            var type = @object.GetType();
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
