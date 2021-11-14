using System;

namespace ActionAndFuncDelegatesInCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var someClient = new SomeClient(MyJsonSerializer.SerializeAsJson, new CdWriter().Write);
            someClient.DoBusinessLogic("Hello World!");
            Console.ReadKey();
        }
    }

    public class SomeClient
    {
        private readonly Func<object, string> serialize;
        private readonly Action<string> persist;

        public SomeClient(Func<object, string> serializerFunction, Action<string> persist)
        {
            this.serialize = serializerFunction;
            this.persist = persist;
        }

        public void DoBusinessLogic(object data)
        {
            var serialized = this.serialize(data);
            this.persist(serialized);
        }
    }

    public class CdWriter
    {
        public void Write(string data) {Console.WriteLine($"Pretending to write [{data}] to CD...");}
    }

    public static class MyJsonSerializer
    {
        public static string SerializeAsJson(object input) => JsonConvert.SerializeObject(input);
    }



}
