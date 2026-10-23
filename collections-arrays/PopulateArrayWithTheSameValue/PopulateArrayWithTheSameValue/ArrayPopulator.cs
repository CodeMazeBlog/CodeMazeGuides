namespace PopulateArrayWithTheSameValue;

public class ArrayPopulator
{
    public Article[] InstantiateArrayManually()
    {
        return
        [
            new() { Title = "How to Copy Array Elements to New Array in C#", LastUpdate = new DateTime(2022, 01, 31) },
            new() { Title = "How to Copy Array Elements to New Array in C#", LastUpdate = new DateTime(2022, 01, 31) }
        ];
    }

    public Article[] FillArray(Article[] array, Article value)
    {
        Array.Fill(array, value);

        return array;
    }

    public Article[] FillArrayWithAditionalParameter(Article[] array, Article value)
    {
        Array.Fill(array, value, 5, 2);

        return array;
    }

    public Article[] FillWithSpan(Article article)
    {
        var articles = new Article[10];
        articles.AsSpan().Fill(article);
        articles.AsSpan(5, 2).Fill(article);

        return articles;
    }

    public Article[] FillRangeWithSpan(Article[] articles, Article article)
    {
        articles.AsSpan(5, 2).Fill(article);

        return articles;
    }

    public Article[] EnumerableRepeat(Article value, int count)
    {
        var articles = Enumerable.Repeat(value, count).ToArray();

        return articles;
    }

    public Article[] ForStatement(Article[] articles, Article article)
    {
        for (int index = 0; index < articles.Length; index++)
        {
            articles[index] = new Article
            {
                Title = article.Title,
                LastUpdate = article.LastUpdate
            };
        }

        return articles;
    }

    public Article[] ForStatementShallowCopy(Article[] articles, Article article)
    {
        for (int index = 0; index < articles.Length; index++)
        {
            articles[index] = article;
        }

        return articles;
    }
}
