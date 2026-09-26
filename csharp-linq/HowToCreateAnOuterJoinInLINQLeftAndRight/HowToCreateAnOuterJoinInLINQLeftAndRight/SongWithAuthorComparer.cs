using System.Diagnostics.CodeAnalysis;

namespace HowToCreateAnOuterJoinInLINQLeftAndRight;

internal class SongWithAuthorComparer : IEqualityComparer<SongWithAuthor>
{
    public bool Equals(SongWithAuthor? x, SongWithAuthor? y)
    {
        return x?.AuthorName == y?.AuthorName && x?.Title == y?.Title;
    }

    public int GetHashCode([DisallowNull] SongWithAuthor obj)
    {
        return HashCode.Combine(obj.Title, obj.AuthorName);
    }
}
