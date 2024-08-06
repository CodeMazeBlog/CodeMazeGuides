namespace DifferencesRecordStructAndRecordClassInCSharp;
public static class DefaultValues
{
    public static PersonRecordClass? GetRecordClassDefaultValue()
    {
        return default(PersonRecordClass);
    }

    public static PersonRecordStruct? GetRecordStructDefaultValue()
    {
        return default(PersonRecordStruct);
    }
}
