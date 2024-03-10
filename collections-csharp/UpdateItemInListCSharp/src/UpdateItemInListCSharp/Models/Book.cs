namespace UpdateItemInListCSharp.Models
{
    public class Book(string author, string isbn, bool isCheckedOut, string title)
    {
        public string Author { get; set; } = author;

        public string ISBN { get; set; } = isbn;

        public bool IsCheckedOut { get; set; } = isCheckedOut;

        public string Title { get; set; } = title;
    }
}
