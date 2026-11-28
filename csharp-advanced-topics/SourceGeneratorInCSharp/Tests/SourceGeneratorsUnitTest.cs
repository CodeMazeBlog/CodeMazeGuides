using Generator;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Tests
{
    [TestClass]
    public class SourceGeneratorsUnitTest
    {
        private const string PersonModelSource = """
            using Generator;

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

        [TestMethod]
        public void WhenGeneratePersonModelService_ThenReturnCorrectOutput()
        {
            var expectedResult = """
                using System.Collections.Generic;
                using System.Linq;
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

            var output = Helper.GetGeneratedOutput(PersonModelSource, "PersonModelService.g.cs");

            Assert.AreEqual(expectedResult.ReplaceLineEndings(), output?.ReplaceLineEndings().TrimEnd());
        }

        [TestMethod]
        public void WhenClassNameHasNoModel_ThenReportErr001()
        {
            var input = """
                using Generator;

                [GenerateService]
                public class Person
                {
                    public int Id { get; set; }
                }
                """;

            var result = Helper.RunGenerator(input);

            var diagnostic = result.Diagnostics.Single();
            Assert.AreEqual("ERR001", diagnostic.Id);
            Assert.IsEmpty(result.GeneratedSources.Where(s => s.HintName == "PersonService.g.cs"));
        }

        [TestMethod]
        public void WhenUnrelatedCodeChanges_ThenGeneratedServiceIsCached()
        {
            var compilation = Helper.CreateCompilation(PersonModelSource);

            GeneratorDriver driver = CSharpGeneratorDriver.Create(
                [new ServiceGenerator().AsSourceGenerator()],
                driverOptions: new GeneratorDriverOptions(
                    IncrementalGeneratorOutputKind.None,
                    trackIncrementalGeneratorSteps: true));

            driver = driver.RunGenerators(compilation);

            var edited = compilation.AddSyntaxTrees(
                CSharpSyntaxTree.ParseText("public class Unrelated { }"));

            driver = driver.RunGenerators(edited);

            var reasons = driver.GetRunResult().Results.Single()
                .TrackedOutputSteps
                .SelectMany(step => step.Value)
                .SelectMany(run => run.Outputs)
                .Select(output => output.Reason)
                .ToList();

            Assert.IsNotEmpty(reasons);
            Assert.IsTrue(reasons.All(reason => reason == IncrementalStepRunReason.Cached));
        }
    }
}
