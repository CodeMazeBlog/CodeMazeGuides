namespace ReturnMultipleValues
{
    public static class MultipleValuesReturner
    {
        public static Tuple<string, bool, int> GetValuesUsingTuple()
        {
            var stringValue = "Some String Value";
            var boolValue = false;
            var intValue = int.MaxValue;

            return Tuple.Create(stringValue, boolValue, intValue);
        }

        public static (string srtValue, bool boolValue, int intValue) GetValuesUsingTupleLiterals()
        {
            var stringValue = "Some String Value";
            var boolValue = false;
            var intValue = int.MaxValue;

            return (stringValue, boolValue, intValue);
        }

        public static void GetValuesUsingOutKeyword(out string srtValue, out bool boolValue, out int intValue)
        {
            srtValue = "Some String Value";
            boolValue = false;
            intValue = int.MaxValue;
        }

        public static object[] GetValuesUsingArrayOfObject()
        {
            return new object[] { "Some String Value", false, int.MaxValue };
        }

        public static Dictionary<string, object> GetValuesUsingDictionary()
        {
            var results = new Dictionary<string, object>();

            results.Add("key1", "Some String Value");
            results.Add("key2", false);
            results.Add("key3", int.MaxValue);

            return results;
        }

        public static MultipleValues GetValuesUsingObjectInstance()
        {
            return new MultipleValues
            {
                StringValue = "Some String Value",
                BoolValue = false,
                IntValue = int.MaxValue
            };
        }
    }
}
