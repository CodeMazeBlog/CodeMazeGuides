namespace JsonObjectsWithHttpClient;

public class PetDto
{
    public long id { get; set; }
    public Category category { get; set; }
    public string name { get; set; }
    public string status { get; set; }
}

public class Category
{
    public string name { get; set; }
}