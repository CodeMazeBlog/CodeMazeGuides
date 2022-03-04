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

            Console.WriteLine("\nThe {0} attribute:", attributeInstance.ToString());

            foreach (var pInfo in pInfoList)
                Console.WriteLine("The {0} property is: {1}", pInfo.Name, pInfo.GetValue(attributeInstance));
        }

        public static string? GetAttribute(Type desiredType, Type desiredAttribute)
        {
            var attributeInstance = Attribute.GetCustomAttribute(desiredType, desiredAttribute);

            if (attributeInstance == null)
                Console.WriteLine("The class {0} does not have atributes.", desiredType.ToString());
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
                Console.WriteLine("The type {0} does not have any methods.", elementType.ToString());
                return attributes;
            }

            foreach (var methodInfo in methodInfoList)
            {
                var attributeList = Attribute.GetCustomAttributes(methodInfo, true);

                if (attributeList.Length == 0)
                {
                    Console.WriteLine("The {0}.{1} method does not have attributes.", elementType.Name, methodInfo.Name);
                    continue;
                }

                Console.WriteLine("The {0}.{1} method's attribute:", elementType.Name, methodInfo.Name);


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
