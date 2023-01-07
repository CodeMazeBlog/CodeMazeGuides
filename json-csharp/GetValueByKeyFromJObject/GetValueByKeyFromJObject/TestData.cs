namespace GetValueByKeyFromJObject
{
    public class TestData
    {
        public string GenerateJsonArray()
        {
            const string cars = $$"""
                [
                  {
                    "name": "Corvette",
                    "make": "Chevrolet",
                    "model": "C8",
                    "year": 2020,
                    "price": {
                      "amount": 67950,
                      "currency": "USD"
                    }
                  },
                  {
                    "name": "Mustang",
                    "make": "Ford",
                    "model": "GT",
                    "year": 2021,
                    "price": {
                      "amount": 52800,
                      "currency": "USD"
                    }
                  },
                  
                  {
                    "name": "Model 3",
                    "make": "Tesla",
                    "model": "Standard Range Plus",
                    "year": 2021,
                    "price": {
                      "amount": 41900,
                      "currency": "USD"
                    }
                  }
                ]
                """;

            return cars;
        }

        public string GenerateSingleJsonObject()
        {
            const string car = $$"""
                {
                    "name": "Charger",
                    "make": "Dodge",
                    "model": "RT",
                    "year": 2019,
                    "price": {
                      "amount": 36100,
                      "currency": "USD"
                    } 
                }
                """;

            return car;
        }
    }
}