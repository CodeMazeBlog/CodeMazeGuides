namespace GetValueByKeyFromJObject
{
    public class TestData
    {
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