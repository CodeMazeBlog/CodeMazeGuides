namespace EqualityOperatorVsEqualsMethodInCSharp
{
    public class MyClass
    {
        public string Property1 { get; set; }
        public int Property2 { get; set; }

        public MyClass(string property1, int property2)
        {
            Property1 = property1;
            Property2 = property2;
        }
    }

    public struct MyStruct
    {
        public string Property1 { get; set; }
        public int Property2 { get; set; }

        public MyStruct(string property1, int property2)
        {
            Property1 = property1;
            Property2 = property2;
        }
    }

    public class Program
    {
        static void Main()
        {
            BehaviorForValueTypes();
            BehaviorForReferenceTypes();
            BehaviorForUserDefinedTypes();
            BehaviorForNullableTypes();
        }

        public static void BehaviorForValueTypes()
        {
            int valueType1 = 5;
            int valueType2 = 5;

            CompareResults(
                ReferenceEquals(valueType1, valueType2), // false
                valueType1 == valueType2, // true
                valueType1.Equals(valueType2) // true
            );
        }

        public static void BehaviorForReferenceTypes()
        {
            object referenceType1 = new string(new[] { 'a', 'b', 'c' });
            object referenceType2 = new string(new[] { 'a', 'b', 'c' });

            CompareResults(
                ReferenceEquals(referenceType1, referenceType2), // false
                referenceType1 == referenceType2, // false
                referenceType1.Equals(referenceType2) // true
            );

            string string1 = "pqr";
            string string2 = "pqr";

            CompareResults(
                ReferenceEquals(string1, string2), // true
                string1 == string2, // true
                string1.Equals(string2) // true
            );

            object referenceType3 = new string(new[] { 'x', 'y', 'z' });
            string string3 = "xyz";

            CompareResults(
                ReferenceEquals(referenceType3, string3), // false
                referenceType3 == string3, // false
                referenceType3.Equals(string3) // true
            );
        }

        public static void BehaviorForUserDefinedTypes()
        {
            // Class
            var classInstance1 = new MyClass("Ahmed", 2);
            var classInstance2 = new MyClass("Ahmed", 2);

            CompareResults(
                ReferenceEquals(classInstance1, classInstance2), // false
                classInstance1 == classInstance2, // false
                classInstance1.Equals(classInstance2) // false
            );

            // Struct
            var structInstance1 = new MyStruct("Ahmed", 2);
            var structInstance2 = new MyStruct("Ahmed", 2);

            CompareResults(
                ReferenceEquals(structInstance1, structInstance2), // false
                null, // structInstance1 == structInstance2 throws a compilation error
                structInstance1.Equals(structInstance2) // true
            );
        }

        public static void BehaviorForNullableTypes()
        {
            int? nullableType1 = null;
            int? nullableType2 = null;

            CompareResults(
                ReferenceEquals(nullableType1, nullableType2), // true
                nullableType1 == nullableType2, // true
                nullableType1.Equals(nullableType2) // true
            );
        }

        public static void CompareResults(bool? a, bool? b, bool? c)
        {
            Console.WriteLine($"Reference: {a}, Equality: {b}, Equals: {c}");
        }
    }
}