using Newtonsoft.Json;

namespace HowToConvertJSONToDataTableInCSharp
{
    public class StudentJson
    {
        public static string CreateStudentJson()
        {
            var json = @"[{""FirstName"":""Conrad"",
                          ""LastName"":""Ushie"",
                          ""BirthYear"":1995,
                          ""Subjects"":[""Physics"",""Chemistry"",""Mathematics"",""English""]}]";

            return json;
        }
    }
}