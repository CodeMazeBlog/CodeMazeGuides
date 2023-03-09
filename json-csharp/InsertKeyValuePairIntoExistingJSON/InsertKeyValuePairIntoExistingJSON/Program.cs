// See https://aka.ms/new-console-template for more information
using InsertKeyValuePairIntoExistingJSON;
using InsertKeyValuePairIntoExistingJSON.Model;

var json =
    @"{
        ""FirstName"": ""Audrey"",
        ""LastName"": ""Spencer"",
        ""ContactDetails"": {
            ""Country"": ""Spain""
        }
    }";

var parser = new Parser(json);

var jasonUpdated = parser.AddStringValue("UserName", "Audrey_Spencer72");
Console.WriteLine(jasonUpdated);

jasonUpdated = parser.AddObjectValue("AdditionalDetails", new AdditionalDetails { FullName = "Audrey Spencer", UserName = "Audrey_Spencer72" });
Console.WriteLine(jasonUpdated);

jasonUpdated = parser.InsertStringValue("ContactDetails", "Address", "4455 Landing Lange");
Console.WriteLine(jasonUpdated);

jasonUpdated = parser.InsertObjectValue("ContactDetails", "Address", new Address { Number = 123, Street = "Abc" });
Console.WriteLine(jasonUpdated);
