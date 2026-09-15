namespace HowToDetectIfADictionaryKeyExistsInCsharp
{
    public class MyClassWithEquality : IEquatable<MyClassWithEquality>
    {
        public int MyNumber { get; set; }

        public MyClassWithEquality(int num)
        {
            MyNumber = num;
        }

        public bool Equals(MyClassWithEquality? other) => other is not null && MyNumber == other.MyNumber;

        public override bool Equals(object? obj)
        {
            if (obj is not MyClassWithEquality) return false;
            return Equals(obj as MyClassWithEquality);
        }

        public override int GetHashCode()
        {
            return MyNumber;
        }
    }
}
