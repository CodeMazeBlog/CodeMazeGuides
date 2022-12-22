namespace TaskAndValueTaskExample;

#nullable disable
public record Weather
{
    public string City { get; set; }
    public DateTime Date { get; set; }
    public int AvgTempratureF { get; set; }
}