namespace WhatsNewInCSharp10;

public record CodeMazeArticle(string Author, string Title, string Comment) : Article(Author, Title);
