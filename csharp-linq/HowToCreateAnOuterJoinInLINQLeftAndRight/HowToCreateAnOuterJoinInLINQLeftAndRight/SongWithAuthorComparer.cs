using System.Diagnostics.CodeAnalysis;

namespace HowToCreateAnOuterJoinInLINQLeftAndRight;

internal class SongWithAuthorComparer : IEqualityComparer<SongWithAuthor>
{
    public bool Equals(SongWithAuthor? x, SongWithAuthor? y)
    {
        if (x?.AuthorName == y?.AuthorName && x?.Title == y?.Title)
        {
            return true;
        }

        return false;
    }

    public int GetHashCode([DisallowNull] SongWithAuthor obj)
    {
        return obj.AuthorName.GetHashCode();
    }
}
