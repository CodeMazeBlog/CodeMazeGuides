using System;

namespace ActionAndFuncDelegatesInCsharp
{
	class Program
	{
		static void Main(string[] args)
		{
			//variable definition and initialization.
			var number1 = 2;
			var number2 = 5;

			//main delagates class initialization.
			Application application = new Application(number1, number2);

			//added to switch from one function to the other without exiting the application.
			application.SwitchView();
			
			Console.ReadKey();
		}
		
	}
	
}
