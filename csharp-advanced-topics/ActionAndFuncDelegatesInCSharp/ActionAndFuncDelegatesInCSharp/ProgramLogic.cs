
namespace ActionAndFuncDelegatesInCSharp
{
	public class ProgramLogic
	{
		public void AddFunc()
		{
			Func<int, int, int> add = (x, y) => x + y;
			var result = add(2, 3);

			Console.WriteLine(result);
		}

		public void GreetAction()
		{
			Action greet = () => Console.WriteLine("Hello!");

			greet();
		}

		public void GreetSomeoneAction()
		{
			Action<string> greetSomeone = name => Console.WriteLine($"Hello, {name}!");

			greetSomeone("John");
		}
	}
}
