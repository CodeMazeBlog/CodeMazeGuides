namespace ContainsString
{
    public class Methods
    {
        public (int, bool) Find(string givenString, string templateText)
        {
            var found = -1;
            var founded = false;
            var givenStringIndex = 0;

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

        public bool ContainsCountry()
        {
            var exists = false;
            var countries = new string[] { "USA", "England", "Germany", "Sweden", "Poland" };

            exists = countries.Contains("Sweden") ? true : false;

            Console.WriteLine("Result of ContainsCountry() method: " + exists);

            return exists;
        }

        public bool ContainsCity()
        {
            var cities = new string[] { "Paris", "Tokyo", "Jakarta", "Delhi", "Mumbai" };

            var result = cities.Any(city => city.Contains("Tokyo", StringComparison.InvariantCultureIgnoreCase));
            Console.WriteLine("Result of ContainsCity() method : " + result);

            return result;
        }

        public bool[] ContainsNameInEmployees()
        {
            var employees = new Employee[]
            {
                new () {Name = "James", Surname = "Smith", Age = 25},
                new () {Name = "Michael", Surname = "Smith", Age = 26},
                new () {Name = "Robert", Surname = "Smith", Age = 27},
                new () {Name = "David", Surname = "Smith", Age = 28},
                new () {Name = "Mary", Surname = "Smith", Age = 29}
            };

            var result = false;
            var results = new bool[5];
            var index = 0;

            foreach (var employee in employees)
            {
                result = employee.Surname.Contains("Smith", StringComparison.InvariantCultureIgnoreCase);
                Console.WriteLine($"Result for {employee.Name}: " + result);

                results[index] = result;
                index++;
            }

            return results;
        }

        public string ContainsArticle()
        {
            var articles = new string[] { "article-1", "article-2", "article-3", "article-4", "article-5" };

            var results = from article in articles
                          where article.Contains("article-1")
                          select article;

            var exists = "";
            foreach (var res in results)
            {
                exists = res;
                Console.WriteLine("Article: " + res);
            }

            return exists;
        }
    }
}
