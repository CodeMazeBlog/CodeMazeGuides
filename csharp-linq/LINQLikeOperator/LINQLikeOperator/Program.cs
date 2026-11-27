string sqlConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Database=BlogDb ;Integrated Security=True";

var contextOption = new DbContextOptionsBuilder<BlogDbContext>()
    .UseSqlServer(sqlConnectionString)
    .LogTo(Console.WriteLine, [DbLoggerCategory.Database.Name], LogLevel.Information)
    .Options;

var blogDbContext = new BlogDbContext(contextOption);
blogDbContext.Database.EnsureCreated();

// Use Contains, StartsWith and EndsWith methods
List<Article> articles = blogDbContext.Articles.Where(x => x.Title.Contains("n")).ToList();
int articleCounts = blogDbContext.Articles.Count(x => x.Title.Contains("n"));
Article? firstArticle = blogDbContext.Articles.FirstOrDefault(x => x.Title.Contains("n"));

articles = blogDbContext.Articles.Where(x => x.Title.StartsWith("n")).ToList();
articles = blogDbContext.Articles.Where(x => x.Title.EndsWith("n")).ToList();

// Use _ wildcard
articles = blogDbContext.Articles.Where(x => x.Title.StartsWith("_n")).ToList();
articles = blogDbContext.Articles.Where(x => EF.Functions.Like(x.Title, "_n%")).ToList();

// Search term from a variable
string searchTerm = "50%";
articles = blogDbContext.Articles.Where(x => x.Title.Contains(searchTerm)).ToList();

string pattern = $"{searchTerm}%";
articles = blogDbContext.Articles.Where(x => EF.Functions.Like(x.Title, pattern)).ToList();

string safePattern = $"{LikePattern.Escape(searchTerm)}%";
articles = blogDbContext.Articles.Where(x => EF.Functions.Like(x.Title, safePattern, @"\")).ToList();

// In-memory list: no LIKE, use string methods or Regex
List<string> titles = ["nop", "mnp", "lmn", "abc"];
List<string> secondLetterN = titles.Where(t => Regex.IsMatch(t, "^.n")).ToList();
Console.WriteLine(string.Join(", ", secondLetterN));