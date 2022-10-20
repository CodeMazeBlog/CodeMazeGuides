using BenchmarkDotNet.Attributes;
using Bogus;
using Microsoft.Extensions.Primitives;
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
        public DataTable dataTable;
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

        public DataTableToJsonTestsMethods()
        {
            dataTable = GenerateDummyDataTable();
        }

        #region Methods
        public string DataTable_NewtonsoftJsonNet(DataTable dataTable)
        {
            if (dataTable == null)
            {
                return string.Empty;
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(dataTable);
        }

        public string DataTable_SystemTextJson(DataTable dataTable)
        {
            if (dataTable == null)
            {
                return string.Empty;
            }

            var data = dataTable.Rows.OfType<DataRow>()
                        .Select(row => dataTable.Columns.OfType<DataColumn>()
                            .ToDictionary(col => col.ColumnName, c => row[c]));
            return System.Text.Json.JsonSerializer.Serialize(data);
        }

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
                        jsonStringBuilder.AppendFormat("\"{0}\":\"{1}\"{2}",
                                dataTable.Columns[j].ColumnName.ToString(),
                                dataTable.Rows[i][j].ToString(),
                                j < dataTable.Columns.Count - 1 ? "," : string.Empty);

                    if (i == dataTable.Rows.Count - 1)
                        jsonStringBuilder.Append("}");
                    else
                        jsonStringBuilder.Append("},");

                }
                jsonStringBuilder.Append("]");
            }

            return jsonStringBuilder.ToString();
        }

        public string DataTable_Linq(DataTable dataTable)
        {
            if (dataTable == null)
            {
                return string.Empty;
            }

            return "[" 
                    + string.Join(",", dataTable.Rows.OfType<DataRow>()
                    .Select(row =>
                        "{" 
                        + string.Join(",", dataTable.Columns.OfType<DataColumn>()
                            .Select(col => string.Format("\"{0}\":\"{1}\"", 
                                                col.ColumnName, 
                                                row[col].ToString())))
                        + "}"))
                    + "]";
        }

        #endregion

        #region Benchmark
        [Benchmark]
        public void NewtonsoftJsonNet()
        {
            DataTable_NewtonsoftJsonNet(dataTable);
        }

        [Benchmark]
        public void SystemTextJson()
        {
            DataTable_SystemTextJson(dataTable);
        }

        [Benchmark]
        public void Linq()
        {
            DataTable_Linq(dataTable);
        }

        [Benchmark]
        public void StringBuilder()
        {
            DataTable_StringBuilder(dataTable);
        }
        #endregion
    }

    public class Student
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int BirthYear { get; set; }
    }
}
