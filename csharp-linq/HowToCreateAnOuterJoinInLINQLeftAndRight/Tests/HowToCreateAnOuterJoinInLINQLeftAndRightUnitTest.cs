using HowToCreateAnOuterJoinInLINQLeftAndRight;

namespace Tests;

public class HowToCreateAnOuterJoinInLINQLeftAndRightUnitTest
{
    [Fact]
    public void GivenTwoDataSources_WhenPerformLeftJoinWithQuerySyntaxMethodCalled_ThenAllItemsFromLeftSourceAreReturned()
    {
        // Arrange
        List<Song> songs =
        [
            new() { Id = 1, Title = "song A", AuthorId = 3 },
            new() { Id = 2, Title = "song B", AuthorId = 1 },
            new() { Id = 3, Title = "song C", AuthorId = 5 },
            new() { Id = 4, Title = "song D", AuthorId = 2 }
        ];

        List<Author> authors =
        [
            new() { Id = 1, Name = "Author A" },
            new() { Id = 9, Name = "Author B" }
        ];

        // Act
        var output = Utilities.PerformLeftJoinWithQuerySyntax( songs, authors ).Count;

        // Assert
        Assert.Equal(songs.Count, output);
    }

    [Fact]
    public void GivenTwoDataSources_WhenPerformLeftJoinWithMethodSyntaxMethodCalled_ThenAllItemsFromLeftSourceAreReturned()
    {
        // Arrange
        List<Song> songs =
        [
            new() { Id = 1, Title = "song A", AuthorId = 3 },
            new() { Id = 2, Title = "song B", AuthorId = 1 },
            new() { Id = 3, Title = "song C", AuthorId = 5 },
            new() { Id = 4, Title = "song D", AuthorId = 2 }
        ];

        List<Author> authors =
        [
            new() { Id = 1, Name = "Author A" },
            new() { Id = 9, Name = "Author B" }
        ];

        // Act
        var output = Utilities.PerformLeftJoinWithMethodSyntax(songs, authors).Count;

        // Assert
        Assert.Equal(songs.Count, output);
    }

    [Fact]
    public void GivenTwoDataSources_WhenPerformRightJoinWithQuerySyntaxMethodCalled_ThenAllItemsFromLeftSourceAreReturned()
    {
        // Arrange
        List<Song> songs =
        [
            new() { Id = 1, Title = "song A", AuthorId = 3 },
            new() { Id = 2, Title = "song B", AuthorId = 1 },
            new() { Id = 3, Title = "song C", AuthorId = 5 },
            new() { Id = 4, Title = "song D", AuthorId = 2 }
        ];

        List<Author> authors =
        [
            new() { Id = 1, Name = "Author A" },
            new() { Id = 9, Name = "Author B" }
        ];

        // Act
        var output = Utilities.PerformRightJoinWithQuerySyntax(songs, authors).Count;

        // Assert
        Assert.Equal(authors.Count, output);
    }

    [Fact]
    public void GivenTwoDataSources_WhenPerformRightJoinWithMethodSyntaxMethodCalled_ThenAllItemsFromLeftSourceAreReturned()
    {
        // Arrange
        List<Song> songs =
        [
            new() { Id = 1, Title = "song A", AuthorId = 3 },
            new() { Id = 2, Title = "song B", AuthorId = 1 },
            new() { Id = 3, Title = "song C", AuthorId = 5 },
            new() { Id = 4, Title = "song D", AuthorId = 2 }
        ];

        List<Author> authors =
        [
            new() { Id = 1, Name = "Author A" },
            new() { Id = 9, Name = "Author B" }
        ];

        // Act
        var output = Utilities.PerformRightJoinWithMethodSyntax(songs, authors).Count;

        // Assert
        Assert.Equal(authors.Count, output);
    }
}

