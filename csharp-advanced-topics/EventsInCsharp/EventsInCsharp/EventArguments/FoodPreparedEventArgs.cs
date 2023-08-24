using EventsInCsharp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventsInCsharp.EventArguments
{
	public class FoodPreparedEventArgs : EventArgs
	{
		public Order Order { get; set; }
	}
}
