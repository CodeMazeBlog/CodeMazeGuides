using Newtonsoft.Json.Linq;

namespace GetValueByKeyFromJObject
{
    public class JObjectManipulation
    {
        public string SingleJsonObject { get; set; }

        public JObjectManipulation()
        {
            InitializeData();
        }

        public void InitializeData()
        {
            var testData = new TestData();
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
            var jsonObject = JObject.Parse(SingleJsonObject);

            var name = (string)jsonObject.SelectToken("name");
            var make = (string)jsonObject.SelectToken("make");
            var model = (string)jsonObject.SelectToken("model");
            var year = (int)jsonObject.SelectToken("year");
            var amount = (int)jsonObject.SelectToken("price.amount");
            var currency = (string)jsonObject.SelectToken("price.currency");

            Console.WriteLine($"A {make} {name} {model} {year} costs {amount} {currency} \n");

            return jsonObject.Count;
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