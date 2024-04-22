using System.Buffers;

namespace App;

public static class MemoryUseCases
{
    /// <summary>
    /// Memory  can be allocated on both the stack and the heap, unlike Span  which is restricted to the stack due to being a ref struct
    /// </summary>
    public static void WorksWithBothStackAndHeap()
    {
        // Allocating Memory<T> on the stack
        Span<int> stackSpan = stackalloc int[3];
        stackSpan[0] = 1;
        stackSpan[1] = 2;
        stackSpan[2] = 3;

        // Creating Memory<T> from stack Span<T>
        var stackMemory = stackSpan.ToArray().AsMemory();

        // Allocating Memory<T> on the heap
        var heapArray = new[] { 4, 5, 6 };
        var heapMemory = heapArray.AsMemory();

        // Displaying contents of stack and heap Memory<T>
        Console.WriteLine("Stack Memory:");
        foreach (var item in stackMemory.Span)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("\nHeap Memory:");
        foreach (var item in heapMemory.Span)
        {
            Console.WriteLine(item);
        }
    }
    
    /// <summary>
    /// String.AsMemory extension method.
    /// </summary>
    public static void StringAsMemoryExtensionMethod()
    {
        const string str = "Hello Code Maze";
        var memory = str.AsMemory();
        
        // Slicing also works with the Memory<char>
        var slice = memory.Slice(6, 8); // "Code Maze"

        // Displaying the slice
        Console.WriteLine(slice.ToString());
    }

    /// <summary>
    /// Ownership models, including the connection between Memory  and the IMemoryOwner interface.
    /// </summary>
    public static void UseMemoryOwner()
    {
        // Rent a block of memory from the shared pool
        using IMemoryOwner<int> owner = MemoryPool<int>.Shared.Rent(10);
        // Get a Memory<T> that represents the rented block of memory
        var memory = owner.Memory;

        // Use the Memory<T>
        for (var i = 0; i < memory.Length; i++)
        {
            memory.Span[i] = i;
        }

        // Display the contents of the Memory<T>
        foreach (var item in memory.Span)
        {
            Console.WriteLine(item);
        }
    }
    
    /// <summary>
    /// Practical usage scenarios such as utilizing MemoryPool, IMemoryOwner, and the IMemoryOwner.Memory property.
    /// </summary>
    /// <param name="filePath"></param>
    public static async Task ProcessFileAsync(string filePath)
    {
        // Rent a block of memory from the shared pool
        using var owner = MemoryPool<byte>.Shared.Rent(4096);

        // Get a Memory<T> that represents the rented block of memory
        Memory<byte> buffer = owner.Memory.Slice(0, 4096);

        await using FileStream stream = File.OpenRead(filePath);

        // Read data from the file into the rented block of memory
        int bytesRead;
        while ((bytesRead = await stream.ReadAsync(buffer)) > 0)
        {
            // Process the data in the buffer
            var data = buffer.Slice(0, bytesRead);
            for (var index = 0; index < data.Span.Length; index++)
            {
                var b = data.Span[index];
                // Convert byte to char and display it
                Console.Write((char)b);
            }
            Console.WriteLine();
        }
    }
}
