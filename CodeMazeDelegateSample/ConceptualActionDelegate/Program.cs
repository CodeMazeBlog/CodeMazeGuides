using System;

namespace ConceptualActionDelegate
{
	public class Foo
	{
		private string bar;
		public Foo(string message)
		{
			this.bar = message;
		}

		public void Echo()
		{
			Console.WriteLine(this.bar);
		}
	}

	public class ActionDelegateConcept
	{
		public static void Main()
		{
			Foo foo = new Foo("Hello Action Delegate!!");
			Action actionFunctionPointer = foo.Echo;
			actionFunctionPointer();
			Console.ReadLine();
		}
	}

}
