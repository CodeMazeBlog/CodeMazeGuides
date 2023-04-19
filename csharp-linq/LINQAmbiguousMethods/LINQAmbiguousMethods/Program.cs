var contextOption = new DbContextOptionsBuilder<BlogDbContext>()
    .UseInMemoryDatabase("BlobDb")
    .Options;

var blogDbContext = new BlogDbContext(contextOption);

if (blogDbContext.Articles is null) return;

// We see error on Where method.
// var articles = blogDbContext.Articles.Where(x => x.Title == "Some Title");

var queryableArticles = ((IQueryable<Article>)blogDbContext.Articles).Where(x => x.Title == "Some Title");
var asyncEnumerableArticles = ((IAsyncEnumerable<Article>)blogDbContext.Articles).Where(x => x.Title == "Some Title");

queryableArticles = blogDbContext.Articles.AsQueryable().Where(x => x.Title == "Some Title");
asyncEnumerableArticles = blogDbContext.Articles.AsAsyncEnumerable().Where(x => x.Title == "Some Title");