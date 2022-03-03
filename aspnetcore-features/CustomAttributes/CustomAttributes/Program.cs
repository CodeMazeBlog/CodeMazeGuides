using CustomAttributes;

Console.WriteLine("Calling {0} method...\n", nameof(CustomAttributeHelper.GetAttribute));
CustomAttributeHelper.GetAttribute(typeof(MyTasks), typeof(TaskDescriptorAttribute));

Console.WriteLine("\n");

Console.WriteLine("Calling {0} method for the MyTask class...\n", nameof(CustomAttributeHelper.GetAttributesOfMethods));
CustomAttributeHelper.GetAttributesOfMethods(typeof(MyTasks));

Console.WriteLine("Calling {0} method for the YourTask class...\n", nameof(CustomAttributeHelper.GetAttributesOfMethods));
CustomAttributeHelper.GetAttributesOfMethods(typeof(YourTasks));