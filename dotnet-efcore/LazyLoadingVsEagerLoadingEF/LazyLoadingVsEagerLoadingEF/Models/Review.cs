namespace LazyLoadingVsEagerLoadingEF;
public class Review
{
    public int ReviewId { get; set; }
    public string? ReviewText { get; set; }
    public int BookId { get; set; }
    public virtual Book? Book { get; set; }
}