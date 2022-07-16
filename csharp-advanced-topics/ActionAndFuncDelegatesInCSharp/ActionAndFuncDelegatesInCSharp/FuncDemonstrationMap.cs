namespace ActionAndFuncDelegatesInCSharp;

public class FuncDemonstrationMap
{
    public class SimpleTextNumberObject
    {
        public string TextValue { get; set; }
    }

    public int SimpleTextNumberObjectToInt(SimpleTextNumberObject o) => int.Parse(o.TextValue);

    public class A
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
    }

    public class B
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    public class ComplexObject
    {
        public SimpleTextNumberObject SimpleTextNumberObject { get; set; }
        public A A { get; set; }
        public B B { get; set; }
    }

    public int SumABWithSimpleTextNumberObject(ComplexObject complex)
    {
        return complex.SimpleTextNumberObject.Map(SimpleTextNumberObjectToInt) + complex.A.Map(a => a.X + a.Y + a.Z) + complex.B.Map(b => b.X + b.Y);
    }
}
