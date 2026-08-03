namespace CreatingMultipleResorcesWithPOST.Models
{
    public record MultipleBooksErrorModel(string Status, string Message): MultipleBooksBase(Status);
}
