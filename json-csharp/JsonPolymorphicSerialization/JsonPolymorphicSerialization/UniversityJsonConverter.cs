using System.Text.Json;
using System.Text.Json.Serialization;

namespace JsonPolymorphicSerialization
{
    public class UniversityJsonConverter : JsonConverter<Person>
    {
        public override bool CanConvert(Type typeToConvert) =>
            typeof(Person).IsAssignableFrom(typeToConvert);

        public override Person Read(ref Utf8JsonReader reader, 
            Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
                throw new JsonException();

            reader.Read();
            if (reader.TokenType != JsonTokenType.PropertyName)
                throw new JsonException();

            string? propertyName = reader.GetString();
            if (propertyName != "PersonType")
                throw new JsonException();

            reader.Read();
            if (reader.TokenType != JsonTokenType.String)
                throw new JsonException();

            var personType = reader.GetString();
            Person person;
            switch (personType)
            {
                case "Student":
                    person = new Student();
                    break;

                case "Professor":
                    person = new Professor();
                    break;

                default:
                    throw new JsonException();
            };

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                    return person;

                if (reader.TokenType == JsonTokenType.PropertyName)
                {
                    propertyName = reader.GetString();
                    reader.Read();
                    switch (propertyName)
                    {
                        case "FirstName":
                            person.FirstName = reader.GetString();
                            break;

                        case "LastName":
                            person.LastName = reader.GetString();
                            break;

                        case "BirthDate":
                            person.BirthDate = reader.GetDateTime();
                            break;

                        case "HomeAddress":
                            person.HomeAddress = reader.GetString();
                            break;

                        case "RegistrationYear":
                            int registrationYear = reader.GetInt32();
                            ((Student)person).RegistrationYear = registrationYear;
                            break;

                        case "OfficeNumber":
                            string? officeNumber = reader.GetString();
                            ((Professor)person).OfficeNumber = officeNumber;
                            break;

                        case "CoursesTaken":
                            if (reader.TokenType == JsonTokenType.StartArray)
                            {
                                while (reader.Read())
                                {
                                    if (reader.TokenType == JsonTokenType.EndArray)
                                        break;

                                    var course = reader.GetString();
                                    if(course != null)
                                        ((Student)person).CoursesTaken.Add(course);
                                }
                            }
                            break;

                        case "CoursesOffered":
                            if (reader.TokenType == JsonTokenType.StartArray)
                            {
                                while (reader.Read())
                                {
                                    if (reader.TokenType == JsonTokenType.EndArray)
                                        break;

                                    var course = reader.GetString();
                                    if (course != null)
                                        ((Professor)person).CoursesOffered.Add(course);
                                }
                            }
                            break;
                    }
                }
            }

            throw new JsonException();
        }

        public override void Write(Utf8JsonWriter writer, Person person, JsonSerializerOptions options)
        {
            writer.WriteStartObject();

            if (person is Student student)
            {
                writer.WriteString("PersonType", "Student");
                writer.WriteString("FirstName", person.FirstName);
                writer.WriteString("LastName", person.LastName);
                writer.WriteString("BirthDate", person.BirthDate);
                writer.WriteString("HomeAddress", person.HomeAddress);
                writer.WriteNumber("RegistrationYear", student.RegistrationYear);
                writer.WriteStartArray("CoursesTaken");
                foreach(var course in student.CoursesTaken)
                {
                    writer.WriteStringValue(course);
                }
                writer.WriteEndArray();

            }
            else if (person is Professor professor)
            {
                writer.WriteString("PersonType", "Professor");
                writer.WriteString("FirstName", person.FirstName);
                writer.WriteString("LastName", person.LastName);
                writer.WriteString("BirthDate", person.BirthDate);
                writer.WriteString("HomeAddress", person.HomeAddress);
                writer.WriteString("OfficeNumber", professor.OfficeNumber);
                writer.WriteStartArray("CoursesOffered");
                foreach (var course in professor.CoursesOffered)
                {
                    writer.WriteStringValue(course);
                }
                writer.WriteEndArray();
            }

            writer.WriteEndObject();
        }
    }


}
