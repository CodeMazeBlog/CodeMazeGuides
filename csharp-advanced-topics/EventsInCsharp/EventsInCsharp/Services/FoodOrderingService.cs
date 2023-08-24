using EventsInCsharp.EventArguments;
using EventsInCsharp.Model;
using System;

namespace EventsInCsharp.Services
{
	public class FoodOrderingService
	{
		public event EventHandler<FoodPreparedEventArgs> FoodPrepared;

		public void PrepareOrder(Order order)
		{
			Console.WriteLine($"Preparing your order '{order.Item}', please wait...");

			OnFoodPrepared(order);
		}

		protected virtual void OnFoodPrepared(Order order)
		{
			FoodPrepared?.Invoke(this, new FoodPreparedEventArgs { Order = order });
		}
	}
}
