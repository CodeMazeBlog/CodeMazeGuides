namespace Tests
{
    [TestClass]
    public class SourceGeneratorsUnitTest
    {
        [TestMethod]
        public void WhenGeneratePersonModelService_ThenReturnCorrectOutput()
        {
            var input = """
                using Generator.Attributes;

                namespace SourceGeneratorInCSharp.Models
                {
                    [GenerateService]
                    public class PersonModel
                    {
                        public int Id { get; set; }

                        public string? Name { get; set; }
                    }
                }
                """;

            var expectedResult = """
                using SourceGeneratorInCSharp.Models;

                namespace SourceGeneratorTests.Services 
                {
                    public partial class PersonModelService
                    {
                        private static readonly List<PersonModel> _list = new();

                        public virtual List<PersonModel> All()
                        {
                            return _list;
                        }

                        public virtual void Add(PersonModel item)
                        {
                            _list.Add(item);
                        }

                        public virtual void Update(PersonModel item)
                        {
                            var existing = _list.Single(x => x.Id == item.Id);

                            _list.Remove(existing);
                            _list.Add(item);
                        }

                        public virtual void Delete(int id)
                        {
                            var existing = _list.Single(x => x.Id == id);

                            _list.Remove(existing);
                        }
                    }
                }
                """;

            var output = Helper.GetGeneratedOutput(input);

            Assert.AreEqual(expectedResult, output);
        }
    }
}
