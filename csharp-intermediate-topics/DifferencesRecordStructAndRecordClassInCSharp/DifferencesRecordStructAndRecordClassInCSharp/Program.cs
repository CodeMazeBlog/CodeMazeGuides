using DifferencesRecordStructAndRecordClassInCSharp;

var recordClassDefaultValue = DefaultValues.GetRecordClassDefaultValue();
var recordStructDefaultValue = DefaultValues.GetRecordStructDefaultValue();
Console.WriteLine($"Record class default value is {(recordClassDefaultValue == null ? "null" : recordClassDefaultValue)}");
Console.WriteLine($"Record struct default value is {(recordStructDefaultValue == null ? "null" : recordStructDefaultValue)}");

public record struct PersonRecordStruct(string Name, DateTime BirthdayDate, int YearsOld, string[] PhoneNumbers);

public readonly record struct PersonRecordStructReadOnly(string Name, DateTime BirthdayDate, int YearsOld, string[] PhoneNumbers);

public record class PersonRecordClass(string Name, DateTime BirthdayDate, int YearsOld, string[] PhoneNumbers);

public record class PersonWithAddressRecordClass(string Name, DateTime BirthdayDate, int YearsOld, string[] PhoneNumbers, string Address) : 
    PersonRecordClass(Name, BirthdayDate, YearsOld, PhoneNumbers);

public record class PersonRecordClassInitSetters
{
    public required string Name { get; init; }
    public DateTime BirthdayDate { get; init; }
    public int YearsOld { get; init; }
    public required string[] PhoneNumbers { get; init; }
};
