using ContainsString;

FindStringExamples findStringExamples = new FindStringExamples();


findStringExamples.ContainsCountry();


findStringExamples.ContainsCity();


findStringExamples.ContainsNameInEmployees();


findStringExamples.ContainsArticle();


var result = findStringExamples.Find("Code Maze", "If you want to read great articles, then let's check Code Maze.");
Console.WriteLine("Result: " + result);