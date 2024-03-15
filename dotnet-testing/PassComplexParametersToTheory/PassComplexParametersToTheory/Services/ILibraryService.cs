namespace PassComplexParametersToTheory.Services;

public interface ILibraryService
{
    bool CheckOutBook(int bookId);
    bool ReturnBook(int bookId);
}
