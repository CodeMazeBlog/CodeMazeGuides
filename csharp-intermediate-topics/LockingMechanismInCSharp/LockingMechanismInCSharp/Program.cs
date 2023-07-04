using LockingMechanismInCSharp;

using Mutex mutex = new(false, "MutexDemo");

if (!mutex.WaitOne(1000))
{
    Console.WriteLine("Application is already running!");
    Console.ReadKey();
    return;
}

Console.WriteLine("Application started!");

Console.WriteLine($"No lock result: {MultithreadWithoutLocking.Execute()}"); // No lock result: result will be different each time, but in almost all cases smaller than 300000
Console.WriteLine($"Interlocked result: {InterlockedClass.Execute()}"); // Interlocked result: 300000
Console.WriteLine($"Lock statement result: {LockStatement.Execute()}"); // Lock statement result: 300000
Console.WriteLine($"Monitor class result: {MonitorClass.Execute()}"); // Monitor class result: 300000
Console.WriteLine($"SpinLock class result: {SpinLockClass.Execute()}"); // SpinLock class result: 300000

SemaphoreClass.Execute();
Console.WriteLine($"ReaderWriterLockClass result: {ReaderWriterLockClass.Execute()}"); // ReaderWriterLockClass result: 300000

Console.WriteLine($"NestedLock result: {NestedLock.Execute()}"); // NestedLock result: 300000

Console.ReadKey();

//ParallelIncrement.Execute();

//ParallelIncrementInterlock.Execute();

//var lockDemo = new Lock();
//lockDemo.Execute();

//var monitorDemo = new LockingMechanismInCSharp.Monitor();
//monitorDemo.Execute();

//var spinLock = new SpinLockDemo();
//spinLock.SpinLockExecute();