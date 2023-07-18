public record LibraryRecord() 
{ 
    public List<BookRecord> Books { get; init; }
    private LibraryRecord(List<BookRecord> books):this()
    {
        Books = books;
    }
}