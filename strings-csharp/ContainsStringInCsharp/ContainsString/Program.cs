using ContainsString;

Methods methods = new Methods();


methods.ContainsCountry();


methods.ContainsCity();


methods.ContainsNameInEmployees();


methods.ContainsArticle();


var result = methods.Find("Code Maze", "If you want to read great articles, then let's check Code Maze.");
Console.WriteLine("Result: " + result);