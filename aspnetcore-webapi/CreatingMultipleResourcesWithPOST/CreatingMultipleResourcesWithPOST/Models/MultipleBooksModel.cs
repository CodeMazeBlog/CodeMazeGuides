namespace CreatingMultipleResorcesWithPOST.Models
{
    public record MultipleBooksModel(string Status, BookModel Message) : MultipleBooksBase(Status);
}
