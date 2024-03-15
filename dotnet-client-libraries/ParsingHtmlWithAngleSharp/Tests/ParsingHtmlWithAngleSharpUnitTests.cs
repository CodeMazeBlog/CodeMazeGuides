using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using ParsingHtmlWithAngleSharp;

namespace Tests;

public class ParsingHtmlWithAngleSharpUnitTests
{
    private const string Html = @"<!DOCTYPE html>
                     <html>
                     <style>
                        .blue {{
                            color: blue;
                        }}
                     </style>
                     <body>
                        <h2>Title</h2>
                        <section id='section'>
                            <div id='articles'>
                                <article id='a1'>Article 1 <em>content</em>.</article>
                            </div>
                            <p class='paragraph'>This is a paragraph.</p>
                            <ul id='list'>
                                <li class='blue'>Item 1</li>
                                <li>Item 2</li>
                                <li class='blue'>Item 3</li>
                            </ul>
                            <form id='sign-up-form'>
                                <label for='username'>Username: </label>
                                <input id='username' name='username' type='text'>

                                <label for='password'>Password: </label>
                                <input id='password' name='password' type='password'>

                                <button id='button' type='submit'>Sign up</button>
                            </form>
                        </section>
                        <footer>Footer</footer>
                     </body>
                     </html>";

    private static readonly StringWriter StringWriter = new();
    
    static ParsingHtmlWithAngleSharpUnitTests()
    {
        Console.SetOut(StringWriter);
    }

    [Fact]
    public async Task WhenParsingHtmlFromString_ThenDocumentIsCreatedAndArticleContentCanBeExtracted()
    {
        var config = Configuration.Default;
        var context = BrowsingContext.New(config);

        var document = await context.OpenAsync(req => req.Content(Html));

        var articles = document
            .QuerySelectorAll<IHtmlElement>("article")
            .ToList();
        var firstArticleTextContent = articles[0].TextContent;

        Assert.Equal("Article 1 content.", firstArticleTextContent);
    }

    [Fact]
    public async Task WhenParsingHtmlFromString_ThenDocumentIsCreatedAndElementsCanBeQueriedWithClassOrId()
    {
        var config = Configuration.Default;
        var context = BrowsingContext.New(config);

        var document = await context.OpenAsync(req => req.Content(Html));

        var paragraphElements = document.Body!
            .QuerySelectorAll<IHtmlParagraphElement>("p")
            .ToList();
        var paragraphElementsLinq = document.All
            .Where(e => e.TagName.Equals("p", StringComparison.InvariantCultureIgnoreCase))
            .ToList();

        Assert.Single(paragraphElements);
        Assert.Single(paragraphElementsLinq);
        Assert.Equal(paragraphElements, paragraphElementsLinq);

        var blueListItemElements = document.Body!
            .QuerySelectorAll<IHtmlListItemElement>("li.blue")
            .ToList();
        var blueListItemElementsLinq = document.All!
            .Where(e => e.LocalName == "li" && e.ClassList.Contains("blue"))
            .ToList();

        Assert.Equal(2, blueListItemElements.Count);
        Assert.Equal(2, blueListItemElementsLinq.Count);

        var formElement = document.Body!.QuerySelector<IHtmlFormElement>("form#sign-up-form");
        var formElementLinq = document.All!
            .First(e => e.TagName.ToLower() == "form"
                        && (e.Id?.Equals("sign-up-form") ?? false));
        var formElementById = document.GetElementById("sign-up-form") as IHtmlFormElement;

        Assert.NotNull(formElement);
        Assert.NotNull(formElementLinq);
        Assert.NotNull(formElementById);
    }

    [Fact]
    public async Task WhenParsingHtmlFromString_ThenDocumentIsCreatedAndElementsCanBeQueriedWithAttributes()
    {
        var config = Configuration.Default;
        var context = BrowsingContext.New(config);

        var document = await context.OpenAsync(req => req.Content(Html));

        var userNameInputElement = document.Body!.QuerySelector<IHtmlInputElement>("form > input[name='username']");
        var userNameInputElementLinq = document.All
            .First(e => e.LocalName == "input" && e.Attributes["name"]?.Value == "username");

        Assert.NotNull(userNameInputElement);
        Assert.Equal("username", userNameInputElement.Id);

        Assert.NotNull(userNameInputElementLinq);
        Assert.Equal("username", userNameInputElementLinq.Id);

        Assert.Equal(userNameInputElement, userNameInputElementLinq);
    }

    [Fact]
    public async Task WhenParsingHtmlFromString_ThenDocumentIsCreatedAndElementPropertiesAreAsExpected()
    {
        var config = Configuration.Default;
        var context = BrowsingContext.New(config);

        var document = await context.OpenAsync(req => req.Content(Html));

        var section = document.Body!.QuerySelector<IHtmlElement>("section")!;

        var sectionInnerHtml = section.InnerHtml;
        var sectionTextContent = section.TextContent;
        var sectionAttributes = section.Attributes;
        var sectionChildren = section.Children;

        var nextSibling = section.NextElementSibling;
        var previousSibling = section.PreviousElementSibling;

        Assert.Equal(@"
                    <div id=""articles"">
                                <article id=""a1"">Article 1 <em>content</em>.</article>
                            </div>
                            <p class=""paragraph"">This is a paragraph.</p>
                            <ul id=""list"">
                                <li class=""blue"">Item 1</li>
                                <li>Item 2</li>
                                <li class=""blue"">Item 3</li>
                            </ul>
                            <form id=""sign-up-form"">
                                <label for=""username"">Username: </label>
                                <input id=""username"" name=""username"" type=""text"">

                                <label for=""password"">Password: </label>
                                <input id=""password"" name=""password"" type=""password"">

                                <button id=""button"" type=""submit"">Sign up</button>
                            </form>
                    ".Trim().Replace(Environment.NewLine, "\n"),
            sectionInnerHtml.Trim());


        Assert.Equal(1, sectionAttributes.Length);
        Assert.Equal(4, sectionChildren.Length);

        Assert.Equal("footer", nextSibling!.TagName.ToLower());
        Assert.Equal("h2", previousSibling!.TagName.ToLower());
    }

    [Fact]
    public async Task WhenParsingHtmlFromUrl_ThenDocumentIsCreatedAndBooksDataIsProperlyRetrieved()
    {
        var booksCatalogUrl = "https://books.toscrape.com/";

        var config = Configuration.Default
            .WithDefaultLoader()
            .WithJs();
        var context = BrowsingContext.New(config);

        var document = await context.OpenAsync(new Url(booksCatalogUrl));

        var booksSection = document.QuerySelector<IHtmlElement>("div.page_inner section")!;
        var bookInfoArticles = booksSection
            .QuerySelectorAll<IHtmlElement>("li > article.product_pod")
            .ToCollection();

        var books = bookInfoArticles.Select(ToBook).ToList();

        Assert.Equal(20, books.Count);
        Assert.Equal("A Light in the Attic", books[0].Title);
        Assert.Equal("Starving Hearts (Triangular Trade Trilogy, #1)", books[10].Title);
        Assert.Equal("It's Only the Himalayas", books[^1].Title);
    }

    [Fact]
    public async Task WhenParsingHtmlFromString_ThenDocumentIsCreatedAndDomManipulationChangesDomAsExpected()
    {
        var config = Configuration.Default
            .WithDefaultLoader()
            .WithJs();

        var context = BrowsingContext.New(config);
        var document = await context.OpenAsync(req => req.Content(Html));

        var paragraphElement = document.CreateElement("p");

        paragraphElement = document.CreateElement<IHtmlParagraphElement>();
        paragraphElement.TextContent = "This is a new paragraph.";

        document.Body.AppendChild(paragraphElement);

        Assert.IsAssignableFrom<IHtmlParagraphElement>(document.Body.Children[^1]);

        var ulElement = document.QuerySelector<IHtmlUnorderedListElement>("ul#list")!;
        var blueLiElement = ulElement.QuerySelector<IHtmlListItemElement>("li.blue")!;

        blueLiElement.Remove();
        if (ulElement.Contains(blueLiElement)) ulElement.RemoveChild(blueLiElement);

        Assert.Equal(2, ulElement.Children.Length);

        var article = document.QuerySelector<IElement>("article#a1")!;
        article.TextContent = "New article content";
        article.InnerHtml = "New article content. <br /> Second article row.";

        article.ClassList.Add("small-article");
        article.Id = "news-article";

        article.SetAttribute("data-category", "news");

        Assert.Contains(article.Attributes, attr => attr.Name == "data-category");

        article.RemoveAttribute("data-category");
    
        Assert.Equal("New article content. <br> Second article row.", article.InnerHtml);
        Assert.IsAssignableFrom<IHtmlBreakRowElement>(article.Children[0]);
        Assert.Equal(1, article.ClassList.Length);
        Assert.Equal("small-article", article.ClassList[0]);
        Assert.NotEmpty(article.Id);
        Assert.DoesNotContain(article.Attributes, attr => attr.Name == "data-category");

        await StringWriter.FlushAsync();

        var button = document.QuerySelector<IHtmlButtonElement>("button#button")!;

        button.AddEventListener("click", (_,
            @event) => Console.WriteLine("Button was clicked!"));
        button.DoClick();

        document.AddEventListener("custom", (_,
            @event) => Console.WriteLine("Custom event fired!"));

        var @event = document.CreateEvent("event");
        @event.Init("custom", false, false);

        document.Dispatch(@event);

        Assert.Equal(
            $"Button was clicked!{Environment.NewLine}Custom event fired!{Environment.NewLine}",
            StringWriter.ToString());
    }


    private static Book ToBook(IElement e)
    {
        var imageUrl = e.QuerySelector<IHtmlImageElement>("div.image_container > a > img.thumbnail")!.Source;
        var titleElement = e.QuerySelector<IHtmlAnchorElement>("h3 > a")!;
        var title = titleElement.Title ?? titleElement.TextContent.Trim();
        var price = decimal.TryParse(
            e.QuerySelector<IHtmlParagraphElement>("div.product_price > p.price_color")!.TextContent.Replace("\u00a3",
                string.Empty),
            out var proPrice)
            ? proPrice
            : default;

        var ratingElementClassList = e.QuerySelector<IHtmlParagraphElement>("p.star-rating")!.ClassList;
        var otherClassName = ratingElementClassList.First(s => s != "star-rating");
        var rating = otherClassName switch
        {
            "One" => 1,
            "Two" => 2,
            "Three" => 3,
            "Four" => 4,
            "Five" => 5,
            _ => 0
        };

        return new Book(title, price, rating, imageUrl!);
    }
}