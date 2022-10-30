using CloneLists;

public class Program
{
    static void Main()
    {
        ToListExample tle = new ToListExample();
        var carList = new List<string>() { "Porsche", "Corvette", "Bugati" };
        List<string> clonedCarList = tle.RunToListExample(carList);

        CopyToMethodExample cme = new CopyToMethodExample();
        var fallList = new List<string>() { "pumpkins", "halloween" };
        string[] fallListCloned = cme.RunCopyToMethodExample(fallList);

        BinaryFormatterExample bfe = new BinaryFormatterExample();
        var resortList = new List<Resort>();
        resortList.Add(new Resort { Name = "Segarden", Location = "Jamaica" });
        resortList.Add(new Resort { Name = "Caribe Hilton", Location = "Puerto Rico" });
        bfe.RunBinaryFormatterExample(resortList);

        ExtensionMethodExample eme = new ExtensionMethodExample();
        var restaurantList = new List<Restaurant>();
        restaurantList.Add(new Restaurant { Name = "Thai Angel", Cuisine = "Thai" });
        restaurantList.Add(new Restaurant { Name = "Cafe Havana", Cuisine = "Cuban" });
        eme.RunExtensionMethodExample(restaurantList);
    }
}