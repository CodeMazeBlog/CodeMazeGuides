using System.Text.Json;
using System.Text.Json.Serialization;

namespace ServerSentEventsForRealtimeUpdates.MVC.Models.Flight;

public class Flight : IFlight
{
    private readonly Random _random = new();

    private readonly List<string> _cities = ["Rio de Janeiro", "New York", "Los Angeles", "Paris", "Rome", "Fatima", "Belgrade"];

    public string Scheduled { get; private set; }
    public string Destination { get; private set; }
    public int Number { get; private set; }
    public int Terminal { get; private set; }
    public string Estimated { get; private set; }
    
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Status Status { get; private set; }
    
    public IFlight GetFlight()
    {
        Scheduled = GetRandomTime(1);
        Destination = _cities[_random.Next(0, 6)];
        Number = _random.Next(1000, 4000);
        Terminal = _random.Next(1, 15);
        Estimated = GetRandomTime(-1);
        Status = (Status)_random.Next(0, 5);
        
        return this;
    }

    public string PrintFlight()
    {
        return JsonSerializer.Serialize(this);
    }

    private string GetRandomTime(int factor)
    {
        var minutes = factor * _random.Next(1, 120);
        return $"{DateTime.Now - TimeSpan.FromMinutes(minutes):t}";
    }
}


