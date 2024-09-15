using Microsoft.Extensions.ServiceDiscovery;
using System.Net;

namespace WhatIsServiceDiscovery.MainAPI;

public class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen();
		builder.Services.AddServiceDiscovery();

		builder.Services.Configure<ConfigurationServiceEndpointProviderOptions>(static options =>
		{
			options.SectionName = "ServiceEndpoints";
			options.ShouldApplyHostNameMetadata = endpoint =>
			{
				return endpoint.EndPoint is DnsEndPoint dns
					&& !dns.Host.Contains("localhost");
			};
		});

		builder.Services.AddHttpClient("shipping", static client =>
		{
			client.BaseAddress = new("https://shipping");
		})
		.AddServiceDiscovery();

		builder.Services.ConfigureHttpClientDefaults(static client =>
		{
			client.AddServiceDiscovery();
		});

		var app = builder.Build();

		if (app.Environment.IsDevelopment())
		{
			app.UseSwagger();
			app.UseSwaggerUI();
		}

		app.UseHttpsRedirection();

		app.MapGet("/callshippingapi", async (HttpClient client) =>
		{
			var response = await client.GetStringAsync("https://shipping/shiporder");

			return $"Shipping API returned: {response}";
		});

		app.Run();
	}
}
