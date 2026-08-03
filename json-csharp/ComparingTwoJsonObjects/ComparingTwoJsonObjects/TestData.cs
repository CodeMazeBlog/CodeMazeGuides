namespace ComparingTwoJsonObjects;

public class TestData
{
    public string GeneratePlainJsonString()
    {
        const string jsonString = $$"""
            {
              "name": "Sporty Ride",
              "make": "Toyota",
              "model": "Supra"
            }
            """ ;

        return jsonString;
    }

    public string GenerateNestedJsonString()
    {
        const string jsonString = $$"""
            {
              "name": "Sporty Ride",
              "make": "Toyota",
              "model": "Supra",
              "price": {
                "amount": 40000.00,
                "currency": "USD"
              }
            }
            """ ;

        return jsonString;
    }
}