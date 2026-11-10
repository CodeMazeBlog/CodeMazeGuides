namespace CopyArrayElements;

public class ElementCopier
{
    public Article[] CopyUsingAssignment(Article[] initialArray)
    {
        var destinationArray = initialArray;

        return destinationArray;
    }

    public Article[] CopyUsingArrayClass(Article[] initialArray)
    {
        var destinationArray = new Article[initialArray.Length];
        Array.Copy(initialArray, destinationArray, initialArray.Length);

        return destinationArray;
    }

    public Article[] CopyPartUsingArrayClass(Article[] initialArray)
    {
        var destinationArray = new Article[initialArray.Length];
        Array.Copy(initialArray, 1, destinationArray, 0, initialArray.Length - 1);

        return destinationArray;
    }

    public Article[] CopyPartUsingRange(Article[] initialArray)
    {
        var destinationArray = initialArray[1..3];

        return destinationArray;
    }

    public Article[] CopyUsingClone(Article[] initialArray)
    {
        var destinationArray = (Article[])initialArray.Clone();

        return destinationArray;
    }

    public Article[] CopyUsingCopyTo(Article[] initialArray)
    {
        var destinationArray = new Article[initialArray.Length];
        initialArray.CopyTo(destinationArray, 0);

        return destinationArray;
    }

    public Article[] CopyUsingRange(Article[] initialArray)
    {
        var destinationArray = initialArray[..];

        return destinationArray;
    }

    public Article[] CopyUsingSpan(Article[] initialArray)
    {
        var destinationArray = new Article[initialArray.Length];
        initialArray.AsSpan().CopyTo(destinationArray);

        return destinationArray;
    }

    public Article[] CopyPartUsingSpan(Article[] initialArray)
    {
        var destinationArray = new Article[initialArray.Length];
        initialArray.AsSpan(1, 2).CopyTo(destinationArray);

        return destinationArray;
    }

    public Article[] CopyUsingCollectionExpression(Article[] initialArray)
    {
        Article[] destinationArray = [.. initialArray];

        return destinationArray;
    }

    public Article[] CopyUsingToArray(Article[] initialArray)
    {
        var destinationArray = initialArray.ToArray();

        return destinationArray;
    }

    public Article[] CopyUsingLinq(Article[] initialArray)
    {
        var destinationArray = initialArray
            .Select(x => new Article { Title = x.Title, LastUpdate = x.LastUpdate })
            .ToArray();

        return destinationArray;
    }

    public Article[] ManuallyCopy(Article[] initialArray)
    {
        var destinationArray = new Article[initialArray.Length];

        for (int index = 0; index < initialArray.Length; index++)
            destinationArray[index] = new Article
            {
                Title = initialArray[index].Title,
                LastUpdate = initialArray[index].LastUpdate
            };

        return destinationArray;
    }
}
