using EventsInCsharp;
using EventsInCsharp.EventArguments;
using EventsInCsharp.Model;
using EventsInCsharp.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Tests
{
	[TestClass]
	public class Tests
	{
		[TestMethod]
		public void givenTheOrder_EventIsRaised()
		{
			var receivedEvents = new List<string>();  
			var order = new Order { Item = "Pizza with extra cheese" }; 

			var orderingService = new FoodOrderingService(); 

			orderingService.FoodPrepared += delegate (object sender, FoodPreparedEventArgs e)
			{
				receivedEvents.Add(e.Order.Item);
			};

			orderingService.PrepareOrder(order); 

			Assert.AreEqual(1, receivedEvents.Count);
			Assert.AreEqual("Pizza with extra cheese", receivedEvents[0]);
		}

		[TestMethod] 
		public void givenTheOrder_whenServicesAreSubscribed_EventIsProcessedByServices()
		{
			var receivedEvents = new List<string>();
			var order = new Order { Item = "Pizza with extra cheese" };

			var orderingService = new FoodOrderingService();
			var appService = new AppService();
			var mailService = new MailService();

			orderingService.FoodPrepared += appService.OnFoodPrepared;
			orderingService.FoodPrepared += mailService.OnFoodPrepared;

			orderingService.PrepareOrder(order);

			Assert.AreEqual("Pizza with extra cheese", appService.Order.Item);
			Assert.AreEqual("Pizza with extra cheese", mailService.Order.Item);
		} 
	}
}
