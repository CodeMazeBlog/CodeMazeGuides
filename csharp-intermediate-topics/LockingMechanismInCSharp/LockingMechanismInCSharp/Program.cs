using LockingMechanismInCSharp;

const string mutexName = "MutexDemo";

try
{
    Mutex.OpenExisting(mutexName);
    Console.WriteLine("More than one instance of the application is running");
}
catch
{
    _ = new Mutex(false, mutexName);
    Console.WriteLine("Only this instance of application is running");
}

Console.WriteLine($"No lock result: {MultithreadWithoutLocking.Execute()}"); // No lock result: result will be different each time, but in almost all cases smaller than 300000
Console.WriteLine($"Interlocked result: {InterlockedClass.Execute()}"); // Interlocked result: 300000
Console.WriteLine($"Lock statement result: {LockStatement.Execute()}"); // Lock statement result: 300000
Console.WriteLine($"Monitor class result: {MonitorClass.Execute()}"); // Monitor class result: 300000
Console.WriteLine($"Mutex class result: {MutexClass.Execute()}"); // Mutex class result: 300000
Console.WriteLine($"SpinLock class result: {SpinLockClass.Execute()}"); // SpinLock class result: 300000

SemaphoreClass.Execute();
Console.WriteLine($"ReaderWriterLockClass result: {ReaderWriterLockSlimClass.Execute()}"); // ReaderWriterLockClass result: 300000

Console.ReadKey();