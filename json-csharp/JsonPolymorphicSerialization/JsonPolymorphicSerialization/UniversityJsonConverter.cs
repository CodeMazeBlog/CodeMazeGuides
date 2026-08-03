using System.Text.Json;
using System.Text.Json.Serialization;

namespace JsonPolymorphicSerialization
{
    public class UniversityJsonConverter : JsonConverter<Member>
    {
        public override bool CanConvert(Type typeToConvert) =>
            typeof(Member).IsAssignableFrom(typeToConvert);

        public override Member Read(ref Utf8JsonReader reader, 
            Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
                throw new JsonException();

            reader.Read();
            if (reader.TokenType != JsonTokenType.PropertyName)
                throw new JsonException();

            string? propertyName = reader.GetString();
            if (propertyName != "MemberType")
                throw new JsonException();

            reader.Read();
            if (reader.TokenType != JsonTokenType.String)
                throw new JsonException();

            var memberType = reader.GetString();
            Member member;
            switch (memberType)
            {
                case "Student":
                    member = new Student();
                    break;

                case "Professor":
                    member = new Professor();
                    break;

                default:
                    throw new JsonException();
            };

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                    return member;

                if (reader.TokenType == JsonTokenType.PropertyName)
                {
                    propertyName = reader.GetString();
                    reader.Read();
                    switch (propertyName)
                    {
                        case "Name":
                            member.Name = reader.GetString();
                            break;

                        case "BirthDate":
                            member.BirthDate = reader.GetDateTime();
                            break;

                        case "RegistrationYear":
                            int registrationYear = reader.GetInt32();
                            if(member is Student)
                                ((Student)member).RegistrationYear = registrationYear;
                            else
                                throw new JsonException();
                            break;

                        case "Rank":
                            string? rank = reader.GetString();
                            if (member is Professor)
                                ((Professor)member).Rank = rank;
                            else
                                throw new JsonException();
                            break;

                        case "IsTenured":
                            bool isTenured = reader.GetBoolean();
                            if (member is Professor)
                                ((Professor)member).IsTenured = isTenured;
                            else
                                throw new JsonException();
                            break;

                        case "Courses":
                            if (member is Student)
                            {
                                if (reader.TokenType == JsonTokenType.StartArray)
                                {
                                    while (reader.Read())
                                    {
                                        if (reader.TokenType == JsonTokenType.EndArray)
                                            break;

                                        var course = reader.GetString();
                                        if (course != null)
                                            ((Student)member).Courses.Add(course);
                                    }
                                }
                            }
                            else
                                throw new JsonException();
                            break;
                    }
                }
            }
            throw new JsonException();
        }

        public override void Write(Utf8JsonWriter writer, Member member, JsonSerializerOptions options)
        {
            writer.WriteStartObject();

            if (member is Student student)
            {
                writer.WriteString("MemberType", "Student");
                writer.WriteString("Name", member.Name);
                writer.WriteString("BirthDate", member.BirthDate);
                writer.WriteNumber("RegistrationYear", student.RegistrationYear);
                writer.WriteStartArray("Courses");
                foreach(var course in student.Courses)
                {
                    writer.WriteStringValue(course);
                }
                writer.WriteEndArray();

            }
            else if (member is Professor professor)
            {
                writer.WriteString("MemberType", "Professor");
                writer.WriteString("Name", member.Name);
                writer.WriteString("BirthDate", member.BirthDate);
                writer.WriteString("Rank", professor.Rank);
                writer.WriteBoolean("IsTenured", professor.IsTenured);
            }

            writer.WriteEndObject();
        }
    }


}
