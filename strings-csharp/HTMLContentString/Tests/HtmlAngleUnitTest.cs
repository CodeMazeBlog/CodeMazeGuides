using HTMLContentString;

namespace Tests;

public class HtmlAngleUnitTest
{
    [Fact]
    public async Task WhenGetHtmlAsString_ThenStringResult()
    {
        var url = "https://www.wikipedia.org/";
        var angle = new HtmlAngle();

        var html = await angle.GetHtmlAsStringAsync(url);
        
        Assert.NotNull(html);
        Assert.IsType<string>(html);
    }

    [Fact]
    public void WhenGetList_ThenSuccess()
    {
        var html = @"<html lang=""en"">
                <head>
                    <meta charset=""UTF-8"">
                    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                    <title>Document</title>
                </head>
                <body>
                    <h1>Welcome</h1>
                    <div>Lorem ipsum dolor sit amet consectetur adipisicing elit.</div>
                    
                    <ul class=""list"">
                        <li>Apple</li>
                        <li>Orange</li>
                        <li>Mango</li>
                    </ul>
                </body>
                </html>";

        var angle = new HtmlAngle();
        var result = angle.GetList(html);
        
        Assert.Equal(["Apple", "Orange", "Mango"], result);
    }
}