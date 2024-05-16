namespace UpdateItemInListCSharp.Models;

public class Book(string title, string author, string isbn, bool isCheckedOut)
{
    public string Author { get; set; } = author;

    public string ISBN { get; set; } = isbn;

    public bool IsCheckedOut { get; set; } = isCheckedOut;

    public string Title { get; set; } = title;

    public override bool Equals(object? obj)
    {
        if (obj is Book b)
        {
            return this.Title == b.Title && this.Author == b.Author && this.ISBN == b.ISBN;
        }
        else
        {
            return false;
        }
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(this.Title, this.Author, this.ISBN);
    }
}
