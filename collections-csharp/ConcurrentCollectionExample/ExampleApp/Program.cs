using ExampleApp.DictionaryExamples;
using ExampleApp.ListAndSetExamples;

if (args.Contains("--race"))
{
    Console.WriteLine("RunRoleManagerDictionaryExampleConcurrent()");
    await RunRoleManagerDictionaryExampleConcurrent();

    return;
}

Console.WriteLine("RunRoleManagerDictionaryExampleSync()");
await RunRoleManagerDictionaryExampleSync();

Console.WriteLine("RunRoleManagerConcurrentDictionaryExampleConcurrent()");
await RunRoleManagerConcurrentDictionaryExampleConcurrent();

Console.WriteLine($"Unique ids: {ListAndSetAlternatives.CountUniqueIds(workers: 4, idsPerWorker: 1000)}");
Console.WriteLine($"Queued entries: {ListAndSetAlternatives.AppendToQueue(workers: 4, itemsPerWorker: 1000)}");
Console.WriteLine($"Locked list entries: {ListAndSetAlternatives.AppendToLockedList(workers: 4, itemsPerWorker: 1000)}");

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