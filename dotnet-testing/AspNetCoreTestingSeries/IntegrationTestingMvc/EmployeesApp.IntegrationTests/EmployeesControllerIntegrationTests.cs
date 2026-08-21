using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace EmployeesApp.IntegrationTests
{
	public class EmployeesControllerIntegrationTests : IClassFixture<TestingWebAppFactory<Program>>
	{
		private readonly HttpClient _client;

		public EmployeesControllerIntegrationTests(TestingWebAppFactory<Program> factory) 
			=> _client = factory.CreateClient();

		[Fact]
		public async Task Index_WhenCalled_ReturnsApplicationForm()
		{
			var response = await _client.GetAsync("/Employees");

			response.EnsureSuccessStatusCode();

			var responseString = await response.Content.ReadAsStringAsync();

			Assert.Contains("Mark", responseString);
			Assert.Contains("Evelin", responseString);
		}

		[Fact]
		public async Task Create_WhenCalled_ReturnsCreateForm()
		{
			var response = await _client.GetAsync("/Employees/Create");

			response.EnsureSuccessStatusCode();

			var responseString = await response.Content.ReadAsStringAsync();

			Assert.Contains("Please provide a new employee data", responseString);
		}

		[Fact]
		public async Task Create_SentWrongModel_ReturnsViewWithErrorMessages()
		{
			var postRequest = new HttpRequestMessage(HttpMethod.Post, "/Employees/Create");

			var formModel = new Dictionary<string, string>
			{
				{ "Name", "New Employee" },
				{ "Age", "25" }
			};

			postRequest.Content = new FormUrlEncodedContent(formModel);
			
			var response = await _client.SendAsync(postRequest);
			
			response.EnsureSuccessStatusCode();
			
			var responseString = await response.Content.ReadAsStringAsync();
			
			Assert.Contains("Account number is required", responseString);
		}

		[Fact] 
		public async Task Create_WhenPOSTExecuted_ReturnsToIndexViewWithCreatedEmployee() 
		{ 
			var postRequest = new HttpRequestMessage(HttpMethod.Post, "/Employees/Create"); 
			
			var formModel = new Dictionary<string, string> 
			{ 
				{ "Name", "New Employee" }, 
				{ "Age", "25" }, 
				{ "AccountNumber", "214-5874986532-21" } 
			}; 
			
			postRequest.Content = new FormUrlEncodedContent(formModel); 
			
			var response = await _client.SendAsync(postRequest); 
			
			response.EnsureSuccessStatusCode(); 
			
			var responseString = await response.Content.ReadAsStringAsync(); 
			
			Assert.Contains("New Employee", responseString); 
			Assert.Contains("214-5874986532-21", responseString); 
		}
	}
}