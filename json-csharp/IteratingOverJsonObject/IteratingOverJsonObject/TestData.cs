namespace IteratingOverJsonObject;

public class TestData
{
    public string GenerateJsonData()
    {
        const string jsonData = $$"""
                        [
                         {
                             "name":"John Doe",
                             "age": 30,
                             "department":"IT"
                         },
                         {
                             "name":"Antonio Weber",
                             "age": 20,
                             "department":"Finance"
                         },
                         {
                             "name":"Jane Doe",
                             "age": 25,
                             "department":"Legal"
                         },
                         {
                             "name":"Ramiro Buck",
                             "age": 28,
                             "department":"IT"
                         },
                         {
                             "name":"Shirley Pearson",
                             "age": 30,
                             "department":"Human Resource"
                         }
                        ]
                        """ ;

        return jsonData;
    }
}