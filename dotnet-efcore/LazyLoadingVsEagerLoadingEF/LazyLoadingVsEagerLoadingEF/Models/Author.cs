namespace LazyLoadingVsEagerLoadingEF;
public class Author
{
    public int AuthorId { get; set; }
    public string? Name { get; set; }
    public virtual ICollection<Book>? Books { get; set; }
}
