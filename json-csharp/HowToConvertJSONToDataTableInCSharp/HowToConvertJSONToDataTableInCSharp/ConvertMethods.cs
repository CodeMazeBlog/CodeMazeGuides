using Newtonsoft.Json;
using System.Data;
using System.Text.Json;
using System.Text.RegularExpressions;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace HowToConvertJSONToDataTableInCSharp
{
    public class ConvertMethods
    {
        private const string _sampleJson
                    = @"[{""FirstName"":""Conrad"",
                          ""LastName"":""Ushie"",
                          ""BirthYear"":1995,
                          ""Subject"":""Physics""}]";

        public static DataTable? UseNewtonsoftJson(string sampleJson = _sampleJson)
        {
            DataTable? dataTable = new();
            if (string.IsNullOrWhiteSpace(sampleJson))
            {
                return dataTable;
            }

            dataTable = JsonConvert.DeserializeObject<DataTable>(sampleJson);

            return dataTable;
        }

        public static DataTable? UseSystemTextJson(string sampleJson = _sampleJson)
        {
            DataTable? dataTable = new();
            if (string.IsNullOrWhiteSpace(sampleJson))
            {
                return dataTable;
            }

            JsonElement data = JsonSerializer.Deserialize<JsonElement>(sampleJson);
            if (data.ValueKind != JsonValueKind.Array)
            {
                return dataTable;
            }

            var dataArray = data.EnumerateArray();
            JsonElement firstObject = dataArray.First();

            var firstObjectProperties = firstObject.EnumerateObject();
            foreach (var element in firstObjectProperties)
            {
                dataTable.Columns.Add(element.Name);
            }

            foreach (var obj in dataArray)
            {
                var objProperties = obj.EnumerateObject();
                DataRow newRow = dataTable.NewRow();
                foreach (var item in objProperties)
                {
                    newRow[item.Name] = item.Value;
                }
                dataTable.Rows.Add(newRow);
            }

            return dataTable;
        }

        public static DataTable? ManuallyConvertJsonToDataTable(string sampleJson = _sampleJson)
        {
            DataTable? dataTable = new();
            if (string.IsNullOrWhiteSpace(sampleJson))
            {
                return dataTable;
            }

            var cleanedJson = Regex.Replace(sampleJson, "\\\\| |\n|\r|\t|\\[|\\]|\"", "");
            var items = Regex.Split(cleanedJson, "},{").AsSpan();
            
            for (int i = 0; i < items.Length; i++)
            {
                items[i] = items[i].Replace("{", "").Replace("}", "");
            }

            var columns = Regex.Split(items[0], ",").AsSpan();
           
            foreach (string column in columns)
            {
                var parts = Regex.Split(column, ":").AsSpan();
                dataTable.Columns.Add(parts[0].Trim());
            }
            
            for (int i = 0; i < items.Length; i++)
            {
                var row = dataTable.NewRow();
                var values = Regex.Split(items[i], ",").AsSpan();
                for (int j = 0; j < values.Length; j++)
                {
                    var parts = Regex.Split(values[j], ":").AsSpan();
                    if (int.TryParse(parts[1].Trim(), out int temp))
                        row[j] = temp;
                    else
                        row[j] = parts[1].Trim();
                }
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }
    }
}