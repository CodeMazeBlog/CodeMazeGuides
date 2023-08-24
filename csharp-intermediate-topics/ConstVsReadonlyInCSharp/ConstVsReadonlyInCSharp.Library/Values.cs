namespace ConstVsReadonlyInCSharp.Library
{
    public class Values
    {
        //V1
        public const string ConstValue = "Const field of version 1.";
        //V2
        //public const string ConstValue = "Const field of version 2.";

        // V1
        public static readonly string ReadonlyValue = "Readonly field of version 1.";
        // V2
        //public static readonly string ReadonlyValue = "Readonly field of version 2.";
    }
}