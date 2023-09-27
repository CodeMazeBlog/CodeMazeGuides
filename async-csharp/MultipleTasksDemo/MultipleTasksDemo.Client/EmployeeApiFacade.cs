using System.Text.Json;
using MultipleTasksDemo.Client.Contracts;

namespace MultipleTasksDemo.Client;

public class EmployeeApiFacade : IEmployeeApiFacade
{
	private readonly JsonSerializerOptions _serializerOptions;
	private static readonly HttpClient _httpClient = new();

	public EmployeeApiFacade()
    {
		_serializerOptions = new JsonSerializerOptions
		{
			PropertyNameCaseInsensitive = true
		};
	}
	public async Task<EmployeeDetails> GetEmployeeDetails(Guid id)
	{
		var response = await _httpClient.GetStringAsync($"https://localhost:7145/api/employee/details/{id}");
		var employeeDetails = JsonSerializer.Deserialize<EmployeeDetails>(response, _serializerOptions);

		await Task.Delay(20);
		//throw new Exception("Test Exception 1");
		return employeeDetails!;
	}

	public async Task<decimal> GetEmployeeSalary(Guid id)
	{
		var response = await _httpClient.GetStringAsync($"https://localhost:7145/api/employee/salary/{id}");
		var salary = JsonSerializer.Deserialize<Salary>(response, _serializerOptions);

		await Task.Delay(10);
		//throw new Exception("Test Exception 2");
		return salary!.SalaryInEuro;
	}

	public async Task<int> GetEmployeeRating(Guid id)
	{
		var response = await _httpClient.GetStringAsync($"https://localhost:7145/api/employee/rating/{id}");
		var rating = JsonSerializer.Deserialize<AppraisalRating>(response, _serializerOptions);

		await Task.Delay(10);
		return rating!.Rating;
	}
}