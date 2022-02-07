namespace ActionDelegateSample
{
	//Real Life Illustration
	public class NotificationService
	{
		public void Send(string Email, string Message)
		{ //Add some logic for email notification } }
		}
	}

	public class User
	{
		public string Name { get; set; }

		public string Email { get; set; }

		public string Phone { get; set; }

		public bool NotifyUser()
		{
			var notificationService = new NotificationService();
			Action<string, string> actionTarget = notificationService.Send; 
			actionTarget(this.Email, $"Welcome, {this.Name}");
			return true;
		}
	}
}

