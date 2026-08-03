using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CustomAttributes
{
    public static class CustomAttributeHelper
    {
        private static void WriteOnTheConsole(Attribute attributeInstance)
        {
            var pInfoList = attributeInstance.GetType().GetProperties(BindingFlags.Public |
                    BindingFlags.Instance |
                    BindingFlags.DeclaredOnly);

            Console.WriteLine($"\nThe {attributeInstance} attribute:");

            foreach (var pInfo in pInfoList)
                Console.WriteLine($"The {pInfo.Name} property is: {pInfo.GetValue(attributeInstance)}");
        }

        public static string? GetAttribute(Type desiredType, Type desiredAttribute)
        {
            var attributeInstance = Attribute.GetCustomAttribute(desiredType, desiredAttribute);

            if (attributeInstance == null)
                Console.WriteLine($"The class {desiredType} does not have atributes.");
            else
                WriteOnTheConsole(attributeInstance);

            return attributeInstance?.ToString();
        }

        public static List<string> GetAttributesOfMethods(Type elementType)
        {
            List<string> attributes = new List<string>();

            var methodInfoList = elementType.GetMethods(BindingFlags.Public |
                BindingFlags.Instance |
                BindingFlags.DeclaredOnly);

            if (methodInfoList == null || methodInfoList.Length == 0)
            {
                Console.WriteLine($"The type {elementType} does not have any methods.");
                return attributes;
            }

            foreach (var methodInfo in methodInfoList)
            {
                var attributeList = Attribute.GetCustomAttributes(methodInfo, true);

                if (attributeList.Length == 0)
                {
                    Console.WriteLine($"The {elementType.Name}.{methodInfo.Name} method does not have attributes.");
                    continue;
                }

                Console.WriteLine($"The {elementType.Name}.{methodInfo.Name} method's attribute:");

                foreach (var att in attributeList)
                {
                    WriteOnTheConsole(att);
                    attributes.Add(methodInfo.Name + "-" + att.ToString());
                }

                Console.WriteLine();
            }

            return attributes;
        }
    }
}
