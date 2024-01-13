using System.Linq.Expressions;
using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;

namespace ParsingHtmlWithAngleSharp;

public class AngleSharpExamples
{
    private const string Html = @"<!DOCTYPE html>
                     <html>
                     <body>
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

                                <button type='submit'>Sign up</button>
                            </form>
                        </section>
                     </body>
                     </html>";

    public static async Task BasicExample()
    {
        var html = @"<!DOCTYPE html>
                     <html>
                     <body>
                        <section id=""section"">
                            <div id=""articles"">
                                <article id=""a1"">Article 1 content.</article>
                                <article id=""a2"">Article 2 content.</article>
                                <article id=""a3"">Article 3 content.</article>
                            </div>
                            <div class=""container""></div>
                            <ul id=""list"">
                                <li>Item 1</li>
                                <li>Item 2</li>
                                <li class=""bold"">Item 3</li>
                                <li>Item 4</li>
                            </ul>
                        </section>
                     </body>
                     </html>";

        var config = Configuration.Default;
        var context = BrowsingContext.New(config);

        var document = await context.OpenAsync(req => req.Content(html));

        var articles = document.QuerySelectorAll<IHtmlElement>("article").ToList();
        var firstArticleTextContent = articles[0].TextContent;

        Console.WriteLine(firstArticleTextContent); // Article 1 content.
    }

    public static async Task QuerySelectors()
    {
        var config = Configuration.Default.WithDefaultLoader().WithDefaultCookies().WithJs();
        var context = BrowsingContext.New(config);

        var document = await context.OpenAsync(req => req.Content(Html));

        var paragraphElements = document.Body!.QuerySelectorAll<IHtmlParagraphElement>("p");
        var paragraphElementsLinq = document.All
            .Where(e => e.TagName.Equals("p", StringComparison.InvariantCultureIgnoreCase));

        var blueListItemElements = document.Body!.QuerySelectorAll<IHtmlListItemElement>("li.blue");
        var blueListItemElementsLinq = document.All!.Where(e => e.LocalName == "li" && e.ClassList.Contains("blue"));

        var formElement = document.Body!.QuerySelector<IHtmlFormElement>("form#sign-up-form");
        var formElementLinq =
            document.All!.First(e => e.TagName.ToLower() == "form" && (e.Id?.Equals("sign-up-form") ?? false));
        var formElementById = document.GetElementById("sign-up-form") as IHtmlFormElement;

        var userNameInputElement = document.Body!.QuerySelector<IHtmlInputElement>("form > input[name='username']");
        var userNameInputElementLinq =
            document.All.Where(e => e.LocalName == "input" && e.Attributes["name"]?.Value == "username");

        var section = document.Body!.QuerySelector<IHtmlElement>("section")!;
        var sectionInnerHtml = section.InnerHtml;
        var sectionTextContent = section.TextContent;
        var sectionAttributes = section.Attributes;
        var sectionChildren = section.Children; // IHtmlCollection<IElement>

        var nextSibling = section.NextSibling;
        var previousSibling = section.PreviousSibling;

        // Getting text nodes:
        var p = document.QuerySelector<IHtmlParagraphElement>(".paragraph")!;
        var textNode = p.ChildNodes
            .First(node => node.NodeType == NodeType.Text
                           && !string.IsNullOrEmpty(node.TextContent.Trim()));
        Console.WriteLine(textNode.TextContent.Trim());

        var ulList = document.GetElementById("ul") as IHtmlUnorderedListElement;

        var title = document.Title;
        var styles = document.StyleSheets;
        var scripts = document.Scripts;

        var images = document.Images;
    }

    public static async Task DomManipulation()
    {
        var config = Configuration.Default
            .WithDefaultLoader()
            .WithJs();

        var context = BrowsingContext.New(config);

        var document = await context.OpenAsync(req => req.Content(Html));

        var paragraphElement = document.CreateElement("p")!;
        // OR
        paragraphElement = document.CreateElement<IHtmlParagraphElement>();

        paragraphElement.TextContent = "This is a new paragraph.";
        paragraphElement.ClassList.Add("new");
        paragraphElement.Id = "paragraph-one";

        paragraphElement.SetAttribute("data-name", "new-paragraph");
        paragraphElement.RemoveAttribute("some-attribute");

        // Add it to the document's body:
        document.Body!.AppendChild(paragraphElement);

        var ulElement = document.QuerySelector<IHtmlUnorderedListElement>("ul#list")!;
        var blueLiElement = ulElement.QuerySelector<IHtmlListItemElement>("li.blue")!;

        // Remove element from the the list:
        blueLiElement.Remove();
        // OR
        ulElement.RemoveChild(blueLiElement);

        var article = document.QuerySelector<IElement>("article#a1")!;
        article.TextContent = "New article content";
        article.InnerHtml = "New article content. <br /> Second article row.";

        // Element siblings:
        var prev = article.PreviousElementSibling;
        var next = article.NextElementSibling;

        var button = document.QuerySelector<IHtmlButtonElement>("button#button")!;
        button.AddEventListener("click", (sender,
            @event) =>
        {
            Console.WriteLine("Button was clicked!");
        });

        // Simulate a click:
        button.DoClick();

        // Custom events:
        document.AddEventListener("custom", (s,
            e) => Console.WriteLine("Custom event fired!"));

        var @event = document.CreateEvent("event");

        @event.Init("custom", false, false);
        document.Dispatch(@event);
    }

    public static async Task Forms()
    {
        var config = Configuration.Default
            .WithDefaultLoader();
        var context = BrowsingContext.New(config);

        var document = await context.OpenAsync(req => req.Content(Html));

        var form = document.QuerySelector<IHtmlFormElement>("#signup-form")!;
        // Get all the elements of the form:
        var formInputElements = form.Elements;

        var userNameInput = document.QuerySelector<IHtmlInputElement>("#username")!;
        // OR
        userNameInput = form.Elements["username"] as IHtmlInputElement;
        userNameInput!.Value = "John";

        var passwordInput = document.QuerySelector<IHtmlInputElement>("#password")!;
        // OR
        passwordInput = form.Elements["password"] as IHtmlInputElement;
        passwordInput.Value = "Doe123!";

        var filesInput = document.QuerySelector<IHtmlInputElement>("input[type=file][name='profile-picture']")!;
        // OR
        filesInput = form.Elements["profile-picture"] as IHtmlInputElement;

        // Attaching a file to a file input
        string imagesPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");
        var fileEntry = new FileEntry("profile-picture.png", "jpeg",
            File.OpenRead(Path.Combine(imagesPath, "profile-picture.jpg")));
        filesInput!.Files.Add(fileEntry);


        var link = document.QuerySelector<IHtmlLinkElement>("a");
        link.DoClick();
        await form.SubmitAsync();
    }

    public static async Task WebScrapingExample()
    {
        const string booksCatalogUrl = "https://books.toscrape.com/";

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
        Console.WriteLine(books.Count); // 20
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

    public record Book(string Title, decimal Price, double Rating, string ImageUrl);


    public class Productx
    {
        public string Name { get; set; } = default!;

        public decimal Price { get; set; }

        public string ImageUrl { get; set; } = default!;

        public double Rating { get; set; }
    }
}