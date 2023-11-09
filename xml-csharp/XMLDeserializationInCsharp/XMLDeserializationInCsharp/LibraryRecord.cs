using XMLDeserializationInCsharp;

public record LibraryRecord()
{
	public List<BookRecord> Books { get; init; } = new();
	private LibraryRecord(List<BookRecord> books) : this()
	{
		Books = books;
	}
}