using HTMLContentString;

var url = "https://www.wikipedia.org/";
var htmlHttp = new HtmlHttp();
var html = await htmlHttp.GetHtmlAsStringAsync(url);