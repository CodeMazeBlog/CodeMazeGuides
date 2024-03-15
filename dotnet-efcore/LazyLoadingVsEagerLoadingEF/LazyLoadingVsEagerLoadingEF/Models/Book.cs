namespace LazyLoadingVsEagerLoadingEF;

public class Book
{
    public int BookId { get; set; }
    public string? Title { get; set; }
    public int AuthorId { get; set; }
    public virtual Author? Author { get; set; }
    public virtual ICollection<Review>? Reviews { get; set; }
}