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
            {
                throw new JsonException();
            }

            reader.Read();
            if (reader.TokenType != JsonTokenType.PropertyName)
            {
                throw new JsonException();
            }

            string? propertyName = reader.GetString();
            if (propertyName != "PersonType")
            {
                throw new JsonException();
            }

            reader.Read();
            if (reader.TokenType != JsonTokenType.String)
            {
                throw new JsonException();
            }

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
                {
                    return person;
                }

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
                                string? courseName = String.Empty;
                                int semester = 0;

                                while (reader.Read())
                                {
                                    if (reader.TokenType == JsonTokenType.EndArray)
                                    {
                                        break;
                                    }

                                    if (reader.TokenType == JsonTokenType.EndObject)
                                    {
                                        ((Student)person).CoursesTaken.Add(new Course()
                                        {
                                            Name = courseName,
                                            Semester = semester
                                        });
                                    }

                                    if (reader.TokenType == JsonTokenType.PropertyName)
                                    {
                                        propertyName = reader.GetString();
                                        reader.Read();
                                        switch (propertyName)
                                        {
                                            case "Name":
                                                courseName = reader.GetString();
                                                break;

                                            case "Semester":
                                                semester = reader.GetInt32();
                                                break;
                                        }
                                    }
                                }
                            }
                            break;

                        case "CoursesOffered":
                            if (reader.TokenType == JsonTokenType.StartArray)
                            {
                                string? courseName = String.Empty;
                                int semester = 0;

                                while (reader.Read())
                                {
                                    if (reader.TokenType == JsonTokenType.EndArray)
                                    {
                                        break;
                                    }

                                    if (reader.TokenType == JsonTokenType.EndObject)
                                    {
                                        ((Professor)person).CoursesOffered.Add(new Course()
                                        {
                                            Name = courseName,
                                            Semester = semester
                                        });
                                    }

                                    if (reader.TokenType == JsonTokenType.PropertyName)
                                    {
                                        propertyName = reader.GetString();
                                        reader.Read();
                                        switch (propertyName)
                                        {
                                            case "Name":
                                                courseName = reader.GetString();
                                                break;

                                            case "Semester":
                                                semester = reader.GetInt32();
                                                break;
                                        }
                                    }
                                }
                            }
                            break;

                        case "HomeAddress":
                            if (reader.TokenType == JsonTokenType.StartObject)
                            {
                                while (reader.Read())
                                {
                                    if (reader.TokenType == JsonTokenType.EndObject)
                                    {
                                        break;
                                    }

                                    if (reader.TokenType == JsonTokenType.PropertyName)
                                    {
                                        propertyName = reader.GetString();
                                        reader.Read();
                                        switch (propertyName)
                                        {
                                            case "Street":
                                                person.HomeAddress.Street = reader.GetString();
                                                break;

                                            case "ZipCode":
                                                person.HomeAddress.ZipCode = reader.GetString();
                                                break;

                                            case "City":
                                                person.HomeAddress.City = reader.GetString();
                                                break;

                                            case "Country":
                                                person.HomeAddress.Country = reader.GetString();
                                                break;
                                        }
                                    }
                                }
                            }
                            break;
                    }
                }
            }

            throw new JsonException();
        }

        private void WritePerson(Utf8JsonWriter writer, Person person)
        {
            writer.WriteString("FirstName", person.FirstName);
            writer.WriteString("LastName", person.LastName);
            writer.WriteString("BirthDate", person.BirthDate);

            writer.WriteStartObject("HomeAddress");
            writer.WriteString("Street", person.HomeAddress.Street);
            writer.WriteString("ZipCode", person.HomeAddress.ZipCode);
            writer.WriteString("City", person.HomeAddress.City);
            writer.WriteString("Country", person.HomeAddress.Country);
            writer.WriteEndObject();
        }

        public override void Write(Utf8JsonWriter writer, Person person, JsonSerializerOptions options)
        {
            writer.WriteStartObject();

            if (person is Student student)
            {
                writer.WriteString("PersonType", "Student");
                WritePerson(writer, person);
                writer.WriteNumber("RegistrationYear", student.RegistrationYear);
                writer.WriteStartArray("CoursesTaken");
                foreach(var course in student.CoursesTaken)
                {
                    writer.WriteStartObject();
                    writer.WriteString("Name", course.Name);
                    writer.WriteNumber("Semester", course.Semester);
                    writer.WriteEndObject();
                }
                writer.WriteEndArray();

            }
            else if (person is Professor professor)
            {
                writer.WriteString("PersonType", "Professor");
                WritePerson(writer, person);
                writer.WriteString("OfficeNumber", professor.OfficeNumber);
                writer.WriteStartArray("CoursesOffered");
                foreach (var course in professor.CoursesOffered)
                {
                    writer.WriteStartObject();
                    writer.WriteString("Name", course.Name);
                    writer.WriteNumber("Semester", course.Semester);
                    writer.WriteEndObject();
                }
                writer.WriteEndArray();
            }

            writer.WriteEndObject();
        }
    }


}
