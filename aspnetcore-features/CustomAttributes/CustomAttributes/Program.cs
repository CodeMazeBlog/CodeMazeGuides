using CustomAttributes;

Console.WriteLine($"Calling {nameof(CustomAttributeHelper.GetAttribute)} method...\n");
CustomAttributeHelper.GetAttribute(typeof(MyTasks), typeof(TaskDescriptorAttribute));

Console.WriteLine();

Console.WriteLine($"Calling {nameof(CustomAttributeHelper.GetAttributesOfMethods)} method for the {nameof(MyTasks)} class...\n");
CustomAttributeHelper.GetAttributesOfMethods(typeof(MyTasks));

Console.WriteLine($"Calling {nameof(CustomAttributeHelper.GetAttributesOfMethods)} method for the {nameof(YourTasks)} class...\n");
CustomAttributeHelper.GetAttributesOfMethods(typeof(YourTasks));