using FluentAssertions;
using InsertKeyValuePairIntoExistingJSON;
using InsertKeyValuePairIntoExistingJSON.Model;
using Newtonsoft.Json.Linq;

namespace KeyValuePaiIntoExistingJSONTests
{
    public class ParserTests
    {
        const string json = @"{
                                ""ContactDetails"": {
                                    ""Country"": ""Spain""
                                }
                              }";

        private readonly Parser _parser;

        public ParserTests() => _parser = new Parser(json);

        [Fact]
        public void WhenCallingAddStringValueMethod_ThenAddNewPropertyIntoExistingJson()
        {
            const string Key = "FirstName";
            const string Value = "Sample";
            var expected = JObject.Parse(@"
                                    { 
                                        ""ContactDetails"" : { 
                                            ""Country"": ""Spain"" 
                                        }, 
                                        ""FirstName"" : ""Sample"" 
                                    }");

            var result = _parser.AddStringValue(Key, Value);

            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void WhenCallingAddObjectValueMethod_ThenAddNewObjectIntoExistingJson()
        {
            const string Key = "AdditionalDetails";
            AdditionalDetails additionalDetails = new() { FullName = "Sample 1", UserName = "Sample 2" };
            var expected = JObject.Parse(@"
                                    { 
                                        ""ContactDetails"" : { 
                                            ""Country"": ""Spain"" 
                                        }, 
                                        ""AdditionalDetails"" : {
                                            ""FullName"" : ""Sample 1"",
                                            ""UserName"" : ""Sample 2""
                                        }
                                    }");

            var result = _parser.AddObjectValue(Key, additionalDetails);

            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void WhenCallingInsertStringValueMethod_ThenInsertNewPropertyIntoExistingJson()
        {
            const string ExistingProperty = "ContactDetails";
            const string NewProperty = "City";
            const string Value = "Madrid";
            var expected = JObject.Parse(@"
                                    { 
                                        ""ContactDetails"" : { 
                                            ""Country"": ""Spain"",
                                            ""City"": ""Madrid""
                                        }
                                    }");

            var result = _parser.InsertStringValue(ExistingProperty, NewProperty, Value);

            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void WhenCallingInsertObjectValueMethod_ThenInsertNewObjectIntoExistingJson()
        {
            const string ExistingProperty = "ContactDetails";
            const string NewProperty = "Address";
            Address address = new() { Number = 123, Street = "Abc" };
            var expected = JObject.Parse(@"
                                    { 
                                        ""ContactDetails"" : { 
                                            ""Country"": ""Spain"",
                                            ""Address"": {
                                                ""Number"": ""123"",
                                                ""Street"": ""Abc""
                                            }
                                        }
                                    }");

            var result = _parser.InsertObjectValue(ExistingProperty, NewProperty, address);

            result.Should().BeEquivalentTo(expected);
        }
    }
}