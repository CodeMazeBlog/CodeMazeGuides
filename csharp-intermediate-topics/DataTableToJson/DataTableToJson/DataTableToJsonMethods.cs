using BenchmarkDotNet.Attributes;
using Bogus;
using System.Data;
using System.Text;

namespace DataTableToJsonTests
{
    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class DataTableToJsonTestsMethods
    {
        private readonly Faker<Student> _faker = new Faker<Student>();
        public DataTable GenerateDummyDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("FirstName");
            dt.Columns.Add("LastName");
            dt.Columns.Add("BirthYear");
            foreach (var item in _faker
                .RuleFor(m => m.FirstName, faker => faker.Person.FirstName)
                .RuleFor(m => m.LastName, faker => faker.Person.LastName)
                .RuleFor(m => m.BirthYear, faker => faker.Person.DateOfBirth.Year)
                .Generate(1000))
            {
                dt.Rows.Add(new object[] { item.FirstName, item.LastName, item.BirthYear });
            }
            return dt;
        }
        public IEnumerable<DataTable> SampleDataTable()
        {
            return new DataTable[1] { GenerateDummyDataTable() };
        }

        [Benchmark]
        [ArgumentsSource(nameof(SampleDataTable))]
        public string DataTable_SystemTextJson(DataTable dataTable)
        {
            if (dataTable == null)
            {
                return string.Empty;
            }

            var data = dataTable.Rows.OfType<DataRow>()
                    .Select(r => dataTable.Columns.OfType<DataColumn>()
                        .ToDictionary(c => c.ColumnName, v => r[v]));
            return System.Text.Json.JsonSerializer.Serialize(data);
        }

        [Benchmark]
        [ArgumentsSource(nameof(SampleDataTable))]
        public string DataTable_StringBuilder(DataTable dataTable)
        {
            if (dataTable == null)
            {
                return string.Empty;
            }

            var jsonStringBuilder = new StringBuilder();
            if (dataTable.Rows.Count > 0)
            {
                jsonStringBuilder.Append("[");
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    jsonStringBuilder.Append("{");
                    for (int j = 0; j < dataTable.Columns.Count; j++)
                    {
                        if (j < dataTable.Columns.Count - 1)
                        {
                            jsonStringBuilder.Append("\"" + dataTable.Columns[j].ColumnName.ToString() + "\":" + "\"" + dataTable.Rows[i][j].ToString() + "\",");
                        }
                        else if (j == dataTable.Columns.Count - 1)
                        {
                            jsonStringBuilder.Append("\"" + dataTable.Columns[j].ColumnName.ToString() + "\":" + "\"" + dataTable.Rows[i][j].ToString() + "\"");
                        }
                    }
                    if (i == dataTable.Rows.Count - 1)
                    {
                        jsonStringBuilder.Append("}");
                    }
                    else
                    {
                        jsonStringBuilder.Append("},");
                    }
                }
                jsonStringBuilder.Append("]");
            }
            return jsonStringBuilder.ToString();
        }


        [Benchmark]
        [ArgumentsSource(nameof(SampleDataTable))]
        public string DataTable_LINQ(DataTable dataTable)
        {
            if (dataTable == null)
            {
                return string.Empty;
            }

            return "[" 
                    + string.Join(",", dataTable.Rows.OfType<DataRow>()
                    .Select(r =>
                        "{" 
                        + string.Join(",", dataTable.Columns.OfType<DataColumn>()
                            .Select(c => 
                                    string.Format("\"{0}\":\"{1}\"", c.ColumnName, r[c].ToString())))
                        + "}"))
                    + "]";
        }

        [Benchmark]
        [ArgumentsSource(nameof(SampleDataTable))]
        public string DataTable_NewtonsoftJsonNet(DataTable dataTable)
        {
            if (dataTable == null)
            {
                return string.Empty;
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(dataTable);
        }

    }

    public class Student
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int BirthYear { get; set; }
    }
}
