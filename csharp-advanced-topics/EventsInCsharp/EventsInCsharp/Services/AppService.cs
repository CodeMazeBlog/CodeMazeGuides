using EventsInCsharp.EventArguments;
using EventsInCsharp.Model;
using System;

namespace EventsInCsharp.Services
{
	public class AppService
	{
		public Order Order { get; set; }

		public void OnFoodPrepared(object source, FoodPreparedEventArgs eventArgs)
		{
			Order = eventArgs.Order as Order;
			Console.WriteLine($"AppService: your food '{eventArgs.Order.Item}' is prepared.");
		}
	}
}
