#region LINQ Method Syntax

var exists = false;
var countries = new string[] { "USA", "England", "Germany", "Sweden", "Poland" };

exists = countries.Contains("Sweden") ? true : false;   

Console.WriteLine(exists);

#endregion

#region LINQ Method Syntax

var articles = new string[] { "article-1", "article-2", "article-3", "article-4", "article-5" };

var results = from article in articles
                where article.Contains("article-1")
                select article;

foreach (var res in results)
{
    Console.WriteLine("Article: " + res);
}

#endregion

#region Manually

var result = find("Code Maze", "If you want to read great articles, then let's check Code Maze.");
Console.WriteLine("Result: " + result);

static (int, bool) find(string givenString, string templateText)
{
    int found = -1;
    var founded = false;
    int givenStringIndex = 0;

    for (int textIndex = 0; textIndex < templateText.Length; textIndex++)
    {
        if (givenString[givenStringIndex] == templateText[textIndex])
        {
            if (givenStringIndex == 0)
                found = textIndex;

            givenStringIndex++;
            if (givenStringIndex >= givenString.Length)
            {
                founded = true;
                return (found, founded);
            }
        }
        else
        {
            givenStringIndex = 0;
            if (found >= 0)
                textIndex = found;
            found = -1;
        }
    }
    return (-1, false);
}

#endregion

#region Contains() with Any() method

var cities = new string[] { "Paris", "Tokyo", "Jakarta", "Delhi", "Mumbai" };

var result1 = cities.Any(city => city.Contains("Tokyo", StringComparison.InvariantCultureIgnoreCase));
Console.WriteLine("Result 1: " + result1);


#endregion

#region Contains() with All() method

Employee[] employees = new Employee[]
{
    new () {Name = "James", Surname = "Smith", Age = 25},
    new () {Name = "Michael", Surname = "Smith", Age = 26},
    new () {Name = "Robert", Surname = "Smith", Age = 27},
    new () {Name = "David", Surname = "Smith", Age = 28},
    new () {Name = "Mary", Surname = "Smith", Age = 29}
};

var result2 = false;

foreach (var employee in employees)
{
    result2 = employee.Surname.Contains("Smith", StringComparison.InvariantCultureIgnoreCase);
    Console.WriteLine($"Result 2 for {employee.Name}: " + result2);
}

public class Employee
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Age { get; set; }
}

#endregion


