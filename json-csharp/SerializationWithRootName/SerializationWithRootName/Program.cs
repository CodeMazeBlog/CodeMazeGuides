namespace SerializationWithRootName
{
    public class Serialization
    {
        public static void Main()
        {
            var car = new Car
            {
                Make = "Rolls Royce",
                Model = "Phantom",
                Year = 2022
            };
            // 1. Use of Wrapper
            var outputJson = CarJsonSerializer.SerializeWithWrapper(car);

            Console.WriteLine(outputJson);

            // 2. Use of Anonymous Class
            outputJson = CarJsonSerializer.SerializeWithAnonymousClass(car);

            Console.WriteLine(outputJson);

            // 3. Use of Custom Serializer
            outputJson = CarJsonSerializer.SerializeWithCustomSerializer(car);

            Console.WriteLine(outputJson);

            // 4. Use of DynamicTypes
            outputJson = CarJsonSerializer.SerializeWithDynamicTypes(car);

            Console.WriteLine(outputJson);

            // 5. Use of Serializer Settings
            outputJson = CarJsonSerializer.SerializeWithJsonSerializerSettings(car);

            Console.WriteLine(outputJson);

            //6. XML serialization
            outputJson = CarXMLSerializer.SerializeToXmlWithRootName(car);

            Console.WriteLine(outputJson);
        }
    }
}