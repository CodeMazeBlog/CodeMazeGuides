namespace HowToCreateAnOuterJoinInLINQLeftAndRight;

public static class Utilities
{
    public static List<Song> Songs =
    [
        new Song() { Id = 1, Title = "Alabama Sundown", AuthorId = 3},
        new Song() { Id = 2, Title = "New Beginning", AuthorId = 1},
        new Song() { Id = 3, Title = "To the Stars", AuthorId = 5},
        new Song() { Id = 4, Title = "First Time Ever", AuthorId = 2},
        new Song() { Id = 5, Title = "Nobody Listens", AuthorId = 4},
        new Song() { Id = 6, Title = "New Love", AuthorId = 1}
    ];

    public static List<Author> Authors =
    [
        new Author() { Id = 1, Name = "Sue Sherrington"},
        new Author() { Id = 2, Name = "Luke Palmer" },
        new Author() { Id = 3, Name = "Gwen Felice" },
        new Author() { Id = 6, Name = "Brian Moore" },
        new Author() { Id = 7, Name = "Roy Cobbler" }
    ];  

    public static List<SongWithAuthor> PerformLeftJoinWithQuerySyntax(
        List<Song> songs, List<Author> authors)
    {
        var results =
            from s in songs
            join a in authors
            on s.AuthorId equals a.Id
            into songsWithAuthors
            from sa in songsWithAuthors.DefaultIfEmpty()
            select new SongWithAuthor { Title = s.Title, AuthorName = sa == null ? "unknown" : sa.Name };

        return results.ToList();
    }

    public static List<SongWithAuthor> PerformRightJoinWithQuerySyntax(
        List<Song> songs, List<Author> authors)
    {
        var results =
            from a in authors
            join s in songs
            on a.Id equals s.AuthorId
            into songsWithAuthors
            from sa in songsWithAuthors.DefaultIfEmpty()
            select new SongWithAuthor { Title = sa == null ? "-" : sa.Title, AuthorName = a.Name };

        return results.ToList();
    }

    public static List<SongWithAuthor> PerformLeftJoinWithMethodSyntax(
        List<Song> songs, List<Author> authors)
    {
        var results = songs
                      .GroupJoin(
                          authors,
                          song => song.AuthorId,
                          author => author.Id,
                          (song, author) => new { song, author }
                      )
                      .SelectMany(
                          left => left.author.DefaultIfEmpty(),
                          (song, author) => new SongWithAuthor
                          {
                              Title = song.song.Title,
                              AuthorName = author == null ? "unknown" : author.Name
                          }
                      );

        return results.ToList();
    }
        
    public static List<SongWithAuthor> PerformRightJoinWithMethodSyntax(
        List<Song> songs, List<Author> authors)
    {
        var results = authors
                      .GroupJoin(
                          songs,
                          author => author.Id,
                          song => song.AuthorId,                          
                          (author, song) => new { author, song }
                      )
                      .SelectMany(
                          right => right.song.DefaultIfEmpty(),
                          (author, song) => new SongWithAuthor
                          {
                              Title = song == null ? "-" : song.Title,
                              AuthorName = author.author.Name,
                          }
                      );

        return results.ToList();
    }
       
    public static List<SongWithAuthor> PerformFullOuterJoin(
        List<Song> songs, List<Author> authors)
    {
        var resultsLeft = PerformLeftJoinWithQuerySyntax(songs, authors);
        var resultsRight = PerformRightJoinWithQuerySyntax(songs, authors);

        var results = resultsLeft.Union(resultsRight, new SongWithAuthorComparer());

        return results.ToList();
    }

    public static List<SongWithAuthor> PerformInnerJoin(
        List<Song> songs, List<Author> authors)
    {
        var results =
            from s in songs
            join a in authors
            on s.AuthorId equals a.Id
            select new SongWithAuthor { Title = s.Title, AuthorName = a.Name };

        return results.ToList();
    }

    public static List<SongWithAuthor> PerformLeftExcludingJoin(
        List<Song> songs, List<Author> authors)
    {
        var resultsLeft = PerformLeftJoinWithQuerySyntax(songs, authors);
        var resultsInner = PerformInnerJoin(songs, authors);

        var results = resultsLeft.Except(resultsInner, new SongWithAuthorComparer());

        return results.ToList();
    }

    public static List<SongWithAuthor> PerformRightExcludingJoin(
        List<Song> songs, List<Author> authors)
    {
        var resultsRight = PerformRightJoinWithQuerySyntax(songs, authors);
        var resultsInner = PerformInnerJoin(songs, authors);

        var results = resultsRight.Except(resultsInner, new SongWithAuthorComparer());

        return results.ToList();
    }

    public static List<SongWithAuthor> PerformFullOuterExcludingJoin(
        List<Song> songs, List<Author> authors)
    {
        var resultsFull = PerformFullOuterJoin(songs, authors);
        var resultsInner = PerformInnerJoin(songs, authors);

        var results = resultsFull.Except(resultsInner, new SongWithAuthorComparer());

        return results.ToList();
    }
}
