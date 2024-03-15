namespace CustomJsonConverter;

public class DataSource 
{
    public static List<Contact> GetContacts() 
    {
        return new List<Contact>() 
        {
            new ("John", Department.Admin, "+1234", new("Street 1","City 1")),
            new ("Jane", Department.CustomerCare, "+2341", new("Street 2", "City 2")),
            new ("Mike", Department.Operations, "+3421", new("Street 3", "City 3"))
        };
    }

    public static string GetJsonOfMultiVariantContacts()
        => @"[
          {
            ""Name"": ""John"",
            ""Department"": ""Admin"",
            ""Address"": {
              ""Street"": ""Street 1"",
              ""City"": ""City 1""
            }
          },
          {
            ""Name"": ""Jane"",
            ""Department"": ""CustomerCare"",
            ""Phone"": ""+2341"",
            ""Address"": {
              ""Street"": ""Street 2"",
              ""City"": ""City 2""
            },
            ""Mobile"": ""0123456""
          },
          {
            ""Name"": ""Mike"",
            ""Department"": ""Operations"",
            ""Address"": {
              ""Street"": ""Street 3"",
              ""City"": ""City 3""
            },
            ""Email"": ""test@test.com""
          }
        ]";
}