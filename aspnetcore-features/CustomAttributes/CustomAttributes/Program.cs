using CustomAttributes;

Console.WriteLine("Calling {0} method...\n", nameof(CustomAttributeHelper.GetTaskAttribute));
CustomAttributeHelper.GetTaskAttribute(typeof(TaskGroup));

Console.WriteLine("\n");

Console.WriteLine("Calling {0} method...\n", nameof(CustomAttributeHelper.GetTaskAttributesOfMethod));
CustomAttributeHelper.GetTaskAttributesOfMethod(typeof(TaskGroup));
