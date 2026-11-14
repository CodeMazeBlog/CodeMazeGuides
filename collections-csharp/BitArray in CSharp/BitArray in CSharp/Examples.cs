using System.Collections;
using System.Numerics;

namespace BitArray_in_CSharp;

public static class Examples
{
    public static void Run()
    {
        // Constructors
        BitArray bitArray1 = new BitArray(8);
        bitArray1.Print();

        BitArray bitArray2 = new BitArray(8, true);
        bitArray2.Print();

        BitArray bitArray3 = new BitArray(new byte[] { 2 });
        bitArray3.Print();

        BitArray bitArray4 = new BitArray(new int[] { 4 });
        bitArray4.Print();

        BitArray bitArray5 = new BitArray(new bool[8]);
        bitArray5.Print();

        BitArray bitArray6 = new BitArray(bitArray1);
        bitArray6.Print();

        Console.WriteLine("--- properties");
        BitArray bitArray = new BitArray(8);
        Console.WriteLine(bitArray.Count);
        Console.WriteLine(bitArray.IsReadOnly);
        Console.WriteLine(bitArray.IsSynchronized);
        bitArray[0] = true;
        Console.WriteLine(bitArray[0]);
        Console.WriteLine(bitArray.Length);
        bitArray.Length = 6;
        Console.WriteLine(bitArray.Length);
        bitArray.Length = 10;
        bitArray.Print();
        lock (bitArray.SyncRoot)
        {
            foreach (var item in bitArray)
            {
            }
        }

        Console.WriteLine("--- methods");
        bitArray.Length = 8;
        Console.WriteLine(bitArray.Get(0));
        bitArray.Set(0, true);
        bitArray.SetAll(true);
        bitArray.Print();

        Console.WriteLine("--- logical");
        LogicalMethods();

        Console.WriteLine("--- HasAllSet/HasAnySet");
        BitArray flags = new BitArray(4);
        Console.WriteLine(flags.HasAnySet());
        flags[2] = true;
        Console.WriteLine(flags.HasAnySet());
        Console.WriteLine(flags.HasAllSet());

        Console.WriteLine("--- CopyTo");
        CopyToBytes();

        Console.WriteLine("--- count set bits");
        Console.WriteLine(CountSetBits(new BitArray(new byte[] { 2, 255 })));

        Console.WriteLine("--- length mismatch");
        try
        {
            new BitArray(4).And(new BitArray(8));
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.GetType().Name);
        }

        Console.WriteLine("--- index past end");
        try
        {
            _ = new BitArray(2)[3];
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.GetType().Name);
        }
    }

    public static void LogicalMethods()
    {
        BitArray bitArray1 = new BitArray(new bool[] { false, false, true, true });
        BitArray bitArray2 = new BitArray(new bool[] { false, true, true, false });

        bitArray1.And(bitArray2).Print();
        bitArray1.Or(bitArray2).Print();
        bitArray1.Xor(bitArray2).Print();
        bitArray2.LeftShift(1).Print();
        bitArray2.RightShift(1).Print();
        bitArray2.Not().Print();
    }

    public static void CopyToBytes()
    {
        BitArray bits = new BitArray(8);
        bits[1] = true;
        bits[3] = true;

        byte[] bytes = new byte[1];
        bits.CopyTo(bytes, 0);

        Console.WriteLine(bytes[0]); // 10
    }

    public static int CountSetBits(BitArray bits)
    {
        int[] words = new int[(bits.Length + 31) / 32];
        bits.CopyTo(words, 0);

        int count = 0;
        foreach (int word in words)
        {
            count += BitOperations.PopCount((uint)word);
        }

        return count;
    }
}
