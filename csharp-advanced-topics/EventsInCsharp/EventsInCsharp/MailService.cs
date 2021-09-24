using EventsInCsharp.Services;
using System;

namespace EventsInCsharp
{
	public class MailService
	{
		public Order Order { get; set; }

		public void OnFoodPrepared(object source, FoodPreparedEventArgs eventArgs)
		{
			Order = eventArgs.Order as Order;
			Console.WriteLine($"MailService: your food '{eventArgs.Order.Item}' is prepared.");
		}
	}
}
