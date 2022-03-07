// Custom interpolated string handlers example
var attribute = "not awesome"; 

var processedMessage = ProcessMessage($"Code maze is {attribute}.");

string ProcessMessage(CustomInterpolatedStringHandler builder) => builder.GetFormattedText();

// Lambda expression improvements
var lambda = [DebuggerStepThrough]() => "Hello world";

// Constant interpolated strings example
const string constantAttribute = "awesome";
const string constantMessage = $"Code maze is {constantAttribute}.";

// Sealing records ToString method example
var codeMazeArticleRepresentation = new CodeMazeArticle("Author", "Title", "Comment").ToString();

// Assignment and declaration in the same deconstruction example
var articles = (new Article("Author", "Title"), new CodeMazeArticle("Author", "Title", "Comment"));
var article = new Article("Another author", "Another title");

(article, CodeMazeArticle codeMazeArticle) = articles;

var areAuthorsEqual = article.Author == codeMazeArticle.Author;
