using Newtonsoft.Json.Linq;

namespace GetValueByKeyFromJObject
{
    public class JObjectManipulation
    {
        public string JsonArray { get; set; }
        public string SingleJsonObject { get; set; }

        public JObjectManipulation()
        {
            InitializeData();
        }

        public void InitializeData()
        {
            var testData = new TestData();
            JsonArray = testData.GenerateJsonArray();
            SingleJsonObject = testData.GenerateSingleJsonObject();
        }

        public int GetValuesUsingIndex()
        {
            var jsonObject = JObject.Parse(SingleJsonObject);

            var name = (string)jsonObject["name"];
            var make = (string)jsonObject["make"];
            var model = (string)jsonObject["model"];
            var year = (int)jsonObject["year"];

            var price = (JObject)jsonObject["price"];
            var amount = (int)price["amount"];
            var currency = (string)price["currency"];

            Console.WriteLine($"A {make} {name} {model} {year} costs {amount} {currency} \n");

            return jsonObject.Count;
        }

        public int GetValuesUsingValueMethod()
        {
            var jsonObject = JObject.Parse(SingleJsonObject);

            var name = jsonObject.Value<string>("name");
            var make = jsonObject.Value<string>("make");
            var model = jsonObject.Value<string>("model");
            var year = jsonObject.Value<string>("year");

            var amount = jsonObject.Value<int>("price.amount");
            var currency = jsonObject.Value<string>("price.currency");

            Console.WriteLine($"A {make} {name} {model} {year} costs {amount} {currency} \n");

            return jsonObject.Count;
        }

        public int GetValuesUsingSelectToken()
        {
            var jArray = JArray.Parse(JsonArray);

            foreach (JObject item in jArray.Children<JObject>())
            {
                var name = (string)item.SelectToken("name");
                var make = (string)item.SelectToken("make");
                var model = (string)item.SelectToken("model");
                var year = (int)item.SelectToken("year");
                var amount = (int)item.SelectToken("price.amount");
                var currency = (string)item.SelectToken("price.currency");

                Console.WriteLine($"A {make} {name} {model} {year} costs {amount} {currency} \n");
            }

            return jArray.Count;
        }


        public int GetValuesUsingTryGetValue()
        {
            JObject jsonObject = JObject.Parse(SingleJsonObject);

            if (jsonObject.TryGetValue("name", out JToken nameToken))
            {
                string name = (string)nameToken;
                Console.WriteLine($"Name: {name}");
            }

            if (jsonObject.TryGetValue("make", out JToken makeToken))
            {
                string make = (string)makeToken;
                Console.WriteLine($"Make: {make}");
            }

            if (jsonObject.TryGetValue("price", out JToken priceToken) && priceToken is JObject priceObject)
            {
                if (priceObject.TryGetValue("amount", out JToken amountToken))
                {
                    int amount = (int)amountToken;
                    Console.WriteLine($"Price amount: {amount}");
                }

                if (priceObject.TryGetValue("currency", out JToken currencyToken))
                {
                    string currency = (string)currencyToken;
                    Console.WriteLine($"Price currency: {currency}");
                }
            }

            return jsonObject.Count;
        }
    }
}
