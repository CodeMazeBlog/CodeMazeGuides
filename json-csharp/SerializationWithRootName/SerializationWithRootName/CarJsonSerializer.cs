using Newtonsoft.Json;
using System.Dynamic;

namespace SerializationWithRootName
{
    public static class CarJsonSerializer
    {
        public static string SerializeWithWrapper(Car car)
        {
            var wrapper = new CarWrapper { MyCar = car };
            var jsonWrapper = JsonConvert.SerializeObject(wrapper);

            return jsonWrapper;
        }

        public static string SerializeWithAnonymousClass(Car car)
        {
            var carAnonymous = new { MyCar = car };
            var jsonAnonymous = JsonConvert.SerializeObject(carAnonymous);

            return jsonAnonymous;
        }

        public static string SerializeWithCustomSerializer(Car car)
        {
            var jsonCustom = JsonConvert.SerializeObject(car, new CarJsonConverter());

            return jsonCustom;
        }

        public static string SerializeWithDynamicTypes(Car car)
        {
            dynamic carDynamic = new ExpandoObject();
            carDynamic.MyCar = new ExpandoObject();
            carDynamic.MyCar.Make = car.Make;
            carDynamic.MyCar.Model = car.Model;
            carDynamic.MyCar.Year = car.Year;

            var jsonDynamic = JsonConvert.SerializeObject(carDynamic);

            return jsonDynamic;
        }

        public static string SerializeWithJsonSerializerSettings(Car car)
        {
            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Objects
            };

            var jsonSettings = JsonConvert.SerializeObject(car, settings);

            return jsonSettings;
        }
    }
}
