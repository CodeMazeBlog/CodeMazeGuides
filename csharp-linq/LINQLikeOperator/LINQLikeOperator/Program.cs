string sqlConnectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;Database=BlogDb ;Integrated Security=True";
DbContextOptions<BlogDbContext> contextOption = new DbContextOptionsBuilder<BlogDbContext>()
    .UseSqlServer(sqlConnectionString)
    .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Name }, LogLevel.Information)
    .Options;
BlogDbContext blogDbContext = new BlogDbContext(contextOption);

blogDbContext.Database.EnsureCreated();
List<Article> articles = blogDbContext.Articles.Where(x => x.Title.Contains("n")).ToList();
int articleCounts = blogDbContext.Articles.Count(x => x.Title.Contains("n"));
Article? firstArticle = blogDbContext.Articles.FirstOrDefault(x => x.Title.Contains("n"));