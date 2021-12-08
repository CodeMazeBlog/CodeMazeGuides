using System;

namespace ConceptualFuncDelegate
{
	public class FuncyMath
	{
		public int DoubleUp(int num)
		{
			return (num * 2);
		}
	}

	public class FuncDelegateConcept
	{
		public static void Main()
		{
			FuncyMath foo = new FuncyMath();
			Func<int, int> funcFunctionPointer = foo.DoubleUp;
			int result = funcFunctionPointer(5);
			Console.WriteLine(result);
			Console.ReadLine();
		}
	}

}
