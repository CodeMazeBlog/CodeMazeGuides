using System;

namespace DelegateExample
{
	class Program
	{
		delegate void MyDelegateMathFuction(int x, int y);

		static void MyAddFuction(int x, int y) 
		{ 
			Console.WriteLine($"Result {x + y}"); 
		}

		static void MyMultiplyFuction(int x, int y) 
		{ 
			Console.WriteLine($"Result {x * y}"); 
		}

		static void Main(string[] args)
		{
			MyDelegateMathFuction delFunction = null;

			delFunction = new MyDelegateMathFuction(MyAddFuction);
			delFunction.Invoke(2, 3);

			delFunction = new MyDelegateMathFuction(MyMultiplyFuction);
			delFunction.Invoke(2, 3);

			Console.ReadLine();
		}
	}
}
