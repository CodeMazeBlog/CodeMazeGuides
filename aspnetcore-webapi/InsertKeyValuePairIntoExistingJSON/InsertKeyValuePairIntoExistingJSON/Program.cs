// See https://aka.ms/new-console-template for more information
using InsertKeyValuePairIntoExistingJSON;

var json =
    @"{
        ""FirstName"": ""Audrey"",
        ""LastName"": ""Spencer"",
        ""ContactDetails"": {
            ""Country"": ""Spain""
        }
    }";

var parser = new Parser(json);

var jasonUpdated = parser.Add("UserName", "Audrey_Spencer72");
Console.WriteLine(jasonUpdated);

jasonUpdated = parser.Insert("ContactDetails", "Address", "4455 Landing Lange");
Console.WriteLine(jasonUpdated);
