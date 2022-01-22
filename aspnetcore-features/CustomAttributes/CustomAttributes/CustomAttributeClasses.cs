using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CustomAttributes
{
    public enum Priorities
    {
        High,
        Mid,
        Low
    }

    public class ManagerTask : Attribute
    {
        public Priorities Priority { get; set; }
        public bool NeedsReport { get; set; }
    }

    public class DeveloperTask : Attribute
    {
        public Priorities Priority { get; set; }
        public string? Description { get; set; }
    }

    public class TaskDescriptor : Attribute
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool NeedsManager { get; set; }
        public int DeveloperCount { get; set; }
    }

    [TaskDescriptor(Name = "The group's Name", Description = "Some descriptions for the task", NeedsManager = true, DeveloperCount = 5)]
    public class TaskGroup
    {
        [ManagerTask(Priority = Priorities.Mid, NeedsReport = true)]

        [DeveloperTask(Priority = Priorities.High, Description = "Some description for the developer")]
        public void Task1()
        {
        }
    }

    public static class CustomAttributeHelper
    {
        public static void GetTaskAttribute(Type type)
        {
            //Access to the instace of TaskDescriptor custom attribute.
            var taskDescriptorAtt = (TaskDescriptor?)Attribute.GetCustomAttribute(type, typeof(TaskDescriptor));

            if (taskDescriptorAtt == null)
            {
                Console.WriteLine("The class {0} has not Attribute.", type.ToString());
            }
            else
            {
                //Gets the Name value.
                Console.WriteLine("The Name Attribute is: {0}.", taskDescriptorAtt.Name);
                //Gets the Description value.
                Console.WriteLine("The Description Attribute is: {0}.", taskDescriptorAtt.Description);
                //Gets the NeedsManager value.
                Console.WriteLine("The NeedsManager Attribute is: {0}.", taskDescriptorAtt.NeedsManager);
                //Gets the DeveloperCount value.
                Console.WriteLine("The DeveloperCount Attribute is: {0}.", taskDescriptorAtt.DeveloperCount);
            }
        }

        public static void GetTaskAttributesOfMethod(Type type)
        {
            //Gets the list of manually declared methods.
            var methodInfoList = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            if (methodInfoList == null || methodInfoList.Length == 0)
            {
                Console.WriteLine("The type {0} has not Method.", type.ToString());
                return;
            }

            //Loads all of the method Infos one by one.
            foreach (var methodInfo in methodInfoList)
            {
                //Gets the instances of the custom attributes per methodInfo.
                var attributeList = Attribute.GetCustomAttributes(methodInfo, false);

                if (attributeList.Length == 0)
                {
                    Console.WriteLine("The {0}.{1} method has not attribute.", type.Name, methodInfo.Name);
                }
                else
                {
                    Console.WriteLine("The {0}.{1} method's Attributes:", type.Name, methodInfo.Name);

                    //Access to the list of loaded custom attributes.
                    foreach (var att in attributeList)
                    {
                        var pInfoList = att.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

                        //Prints the class name of the custom attribute on the console.
                        Console.WriteLine("\nThe {0} Attribute(s):", att.ToString());

                        //Prints the value of the custom attributes on the console.
                        foreach (var pInfo in pInfoList)
                            Console.WriteLine("The {0} Attribute is: {1}", pInfo.Name, pInfo.GetValue(att));
                    }
                }
            }
        }
    }
}
