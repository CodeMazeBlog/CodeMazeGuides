using System;
using System.Collections.Generic;
using System.Text;

namespace EventsInCsharp.Services
{
	public class FoodPreparedEventArgs : EventArgs
	{
		public Order Order { get; set; }
	}
}
