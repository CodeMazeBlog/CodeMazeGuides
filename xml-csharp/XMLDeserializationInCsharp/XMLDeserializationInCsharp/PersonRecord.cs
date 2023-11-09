public record PersonRecord(string Name, int Age)
{
	public PersonRecord() : this("", int.MinValue)
	{

	}
}