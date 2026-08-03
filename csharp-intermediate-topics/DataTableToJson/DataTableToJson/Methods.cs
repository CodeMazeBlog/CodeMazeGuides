using System.Data;
using System.Text;

namespace DataTableToJsonTest
{
    public static class Methods
    {
        public static string DataTableNewtonsoftJsonNet(DataTable dataTable)
        {
            if (dataTable == null)
            {
                return string.Empty;
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(dataTable);
        }

        public static string DataTableSystemTextJson(DataTable dataTable)
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

        public static string DataTableStringBuilder(DataTable dataTable)
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

                    jsonStringBuilder.Append(i == dataTable.Rows.Count - 1 ? "}" : "},");
                }
                jsonStringBuilder.Append("]");
            }

            return jsonStringBuilder.ToString();
        }

        public static string DataTableLinq(DataTable dataTable)
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

    }
}
