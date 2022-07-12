using ContainsString;

var findStringExamples = new FindStringExamples();


findStringExamples.ContainsCountry();


findStringExamples.ContainsCityWithoutCaseSensetive();

findStringExamples.ContainsCityWithCaseSensetive();


findStringExamples.ContainsNameInEmployees();


findStringExamples.ContainsArticle();


var result = findStringExamples.Find("Code Maze", "If you want to read great articles, then let's check Code Maze.");
Console.WriteLine("Result: " + result);