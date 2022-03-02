const string attribute = "not awesome";
const string message = $"Code maze is {attribute}.";

ProcessMessage($"Code maze is {attribute}.");

var codeMazeArticleRepresentation = new CodeMazeArticle("Author", "Title", "Comment").ToString();

string ProcessMessage(CustomInterpolatedStringHandler builder) => builder.GetFormattedText();

var articles = (new Article("Author", "Title"), new CodeMazeArticle("Author", "Title", "Comment"));
Article article = new Article("Another author", "Another title");

(article, CodeMazeArticle codeMazeArticle) = articles;
