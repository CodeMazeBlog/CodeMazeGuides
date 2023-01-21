using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace HowToConvertJSONToDataTableInCSharp
{
    public class ConvertMethods
    {
        private static readonly string _sampleJson = StudentJson.CreateStudentJson();

        public static DataTable UseNewtonsoftJson()
        {
            DataTable dataTable = new();
            if (string.IsNullOrWhiteSpace(_sampleJson))
            {
                return dataTable;
            }
            dataTable = JsonConvert.DeserializeObject<DataTable>(_sampleJson);
            
            return dataTable;
        }

        public static DataTable UseSystemTextJson()
        {
            DataTable dataTable = new();
            if (string.IsNullOrWhiteSpace(_sampleJson))
            {
                return dataTable;
            }
            JsonElement data = JsonSerializer.Deserialize<JsonElement>(_sampleJson);
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

        public static DataTable ManuallyConvertJsonToDataTable()
        {
            DataTable dataTable = new DataTable();
            if (string.IsNullOrWhiteSpace(_sampleJson))
            {
                return dataTable;
            }
            JArray array = JArray.Parse(_sampleJson);
            if (array.Count == 0)
            {
                return dataTable;
            }
            JObject firstObject = (JObject)array[0];
            var properties = firstObject.Properties();
            foreach (var property in properties)
            {
                dataTable.Columns.Add(property.Name);
            }
            foreach (var obj in array)
            {
                DataRow dataRow = dataTable.NewRow();
                foreach (var property in properties)
                {
                    dataRow[property.Name] = obj[property.Name];
                }
                dataTable.Rows.Add(dataRow);
            }

            return dataTable;
        }
    }
}
