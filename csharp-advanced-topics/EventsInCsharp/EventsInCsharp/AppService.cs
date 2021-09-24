using EventsInCsharp.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventsInCsharp
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
