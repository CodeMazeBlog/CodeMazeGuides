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
        public static void GetTaskAttribute(Type type)
        {
            var taskDescriptorAtt = (TaskDescriptor?)Attribute.GetCustomAttribute(type, typeof(TaskDescriptor));

            if (taskDescriptorAtt == null)
            {
                Console.WriteLine("The class {0} has not Attribute.", type.ToString());
            }
            else
            {
                Console.WriteLine("The Name Attribute is: {0}.", taskDescriptorAtt.Name);
                Console.WriteLine("The Description Attribute is: {0}.", taskDescriptorAtt.Description);
                Console.WriteLine("The NeedsManager Attribute is: {0}.", taskDescriptorAtt.NeedsManager);
                Console.WriteLine("The DeveloperCount Attribute is: {0}.", taskDescriptorAtt.DeveloperCount);
            }
        }

        public static void GetTaskAttributesOfMethod(Type type)
        {
            var methodInfoList = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            if (methodInfoList == null || methodInfoList.Length == 0)
            {
                Console.WriteLine("The type {0} has not Method.", type.ToString());
                return;
            }

            foreach (var methodInfo in methodInfoList)
            {
                var attributeList = Attribute.GetCustomAttributes(methodInfo, false);

                if (attributeList.Length == 0)
                {
                    Console.WriteLine("The {0}.{1} method has not attribute.", type.Name, methodInfo.Name);
                }
                else
                {
                    Console.WriteLine("The {0}.{1} method's Attributes:", type.Name, methodInfo.Name);

                    foreach (var att in attributeList)
                    {
                        var pInfoList = att.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

                        Console.WriteLine("\nThe {0} Attribute(s):", att.ToString());

                        foreach (var pInfo in pInfoList)
                            Console.WriteLine("The {0} Attribute is: {1}", pInfo.Name, pInfo.GetValue(att));
                    }
                }
            }
        }
    }
}
