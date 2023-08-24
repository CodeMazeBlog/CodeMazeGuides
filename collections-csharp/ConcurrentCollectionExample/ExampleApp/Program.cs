using ExampleApp.DictionaryExamples;

// Console.WriteLine("RunRoleManagerDictionaryExampleConcurrent()");
// await RunRoleManagerDictionaryExampleConcurrent();

// Console.WriteLine("\n\n");
Console.WriteLine("RunRoleManagerConcurrentDictionaryExampleConcurrent()");
await RunRoleManagerConcurrentDictionaryExampleConcurrent();

static async Task RunRoleManagerDictionaryExampleSync()
{
    var roleManager = new RoleManagerDictionary();
    await roleManager.TryAssign("Admin", 1);
    await roleManager.TryAssign("Admin", 2);
    await roleManager.TryAssign("Admin", 3);

    roleManager.PrintAll();
}

static async Task RunRoleManagerDictionaryExampleConcurrent()
{
    var roleManager = new RoleManagerDictionary();
    var task1 = roleManager.TryAssign("Admin", 1);
    var task2 = roleManager.TryAssign("Admin", 2);
    var task3 = roleManager.TryAssign("Admin", 3);

    await Task.WhenAll(task1, task2, task3);
    roleManager.PrintAll();
}

static async Task RunRoleManagerConcurrentDictionaryExampleConcurrent()
{
    var concurrentRoleManager = new RoleManagerConcurrentDictionary();
    var task1 = concurrentRoleManager.TryAssign("Admin", 1);
    var task2 = concurrentRoleManager.TryAssign("Admin", 2);
    var task3 = concurrentRoleManager.TryAssign("Admin", 3);

    await Task.WhenAll(task1, task2, task3);
    concurrentRoleManager.PrintAll();
}