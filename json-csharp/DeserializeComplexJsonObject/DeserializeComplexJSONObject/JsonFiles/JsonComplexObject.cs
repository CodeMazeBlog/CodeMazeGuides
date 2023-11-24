namespace DeserializeComplexJSONObject.JsonFiles
{
    public static class JsonComplexObject
    {
        public const string Json = @" 
        {
          ""id"": ""854e469f-76ec-4036-b10e-2305d5063cc4"",
          ""name"": ""Microsoft"",
          ""cofounders"": [
            {
                ""id"": ""0d61b68c-f05e-4e6c-822d-6769578f241c"",
              ""name"": ""Bill Gates""
            },
            {
                ""id"": ""3ef95ce8-7302-470c-afc2-f59d2a3cb2df"",
              ""name"": ""Paul Allen""
            }
          ],
          ""employees"": [
            {
                ""id"": ""6416b2c8-9f8f-4a8e-9f74-ce919ee08a2f"",
              ""fullName"": ""Jane Doe"",
              ""anualSalary"": 150000,
              ""position"": {
                    ""id"": ""b57fe795-0fbf-4da8-bab8-c6a2ba4e709d"",
                ""description"": ""Engineer Manager""
              },
              ""benefits"": [
                {
                    ""id"": ""e3257cb7-0984-42c1-b432-d640dfb0a029"",
                  ""additional"": 3000,
                  ""description"": ""Additional Bonus""
                },
                {
            ""id"": ""7cda860a-695b-4aac-956a-fb7245c75ef3"",
                  ""additional"": 2500,
                  ""description"": ""Paid Vacation""
                }
              ]
            },
            {
            ""id"": ""4fcd662a-e317-45f8-a5fc-d6c7042f2be8"",
              ""fullName"": ""John Doe"",
              ""anualSalary"": 100000,
              ""position"": {
                ""id"": ""47285220-ed1a-42fb-a623-33daff09c6d2"",
                ""description"": ""Software Engineer""
              },
              ""benefits"": []
            },
            {
            ""id"": ""6b33db47-0d19-46de-8851-9250c97e5302"",
              ""fullName"": ""Anakin Skywalker"",
              ""anualSalary"": 97000,
              ""position"": {
                ""id"": ""47285220-ed1a-42fb-a623-33daff09c6d2"",
                ""description"": ""Software Engineer""
              },
              ""benefits"": [
                {
                ""id"": ""e3257cb7-0984-42c1-b432-d640dfb0a029"",
                  ""additional"": 3000,
                  ""description"": ""Additional Bonus""
                },
                {
                ""id"": ""7cda860a-695b-4aac-956a-fb7245c75ef3"",
                  ""additional"": 2500,
                  ""description"": ""Paid Vacation""
                }
              ]
            }
          ]
        }";
    }
}
