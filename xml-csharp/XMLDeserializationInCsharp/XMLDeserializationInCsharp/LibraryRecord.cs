using XMLDeserializationInCsharp;

public record LibraryRecord()
{
	public List<BookRecord> Books { get; init; } = new();
}