using HowToConvertJSONToDataTableInCSharp;
using System.Data;

namespace Tests
{
    public class ConvertMethodTests
    {
        [Fact]
        public void GivenJsonString_WhenUsingNewtonsoftJson_ThenDeserializeToADataTable()
        {
            var dataTable = ConvertMethods.UseNewtonsoftJson();
            var studentRow = dataTable.Rows[0];
            var FirstName = "Conrad";
            var LastName = "Ushie";
            var BirthYear = 1995;
            var Subject = "Physics";

            Assert.IsType<DataTable?>(dataTable);
            Assert.True(dataTable.Rows.Count > 0);
            Assert.Equal(studentRow["FirstName"].ToString(), FirstName);
            Assert.Equal(studentRow["LastName"].ToString(), LastName);
            Assert.Equal(Convert.ToInt32(studentRow["BirthYear"]), BirthYear);
            Assert.Equal(studentRow["Subject"].ToString(), Subject);

        }

        [Fact]
        public void GivenJsonString_WhenUsingSystemTextJson_ThenDeserializeToADataTable()
        {
            var dataTable = ConvertMethods.UseSystemTextJson();
            var studentRow = dataTable.Rows[0];
            var FirstName = "Conrad";
            var LastName = "Ushie";
            var BirthYear = 1995;
            var Subject = "Physics";

            Assert.IsType<DataTable?>(dataTable);
            Assert.True(dataTable.Rows.Count > 0);
            Assert.Equal(studentRow["FirstName"].ToString(), FirstName);
            Assert.Equal(studentRow["LastName"].ToString(), LastName);
            Assert.Equal(Convert.ToInt32(studentRow["BirthYear"]), BirthYear);
            Assert.Equal(studentRow["Subject"].ToString(), Subject);
        }

        [Fact]
        public void GivenJsonString_WhenManuallyConstructingADataTable_ThenDeserializeToADataTable()
        {
            var dataTable = ConvertMethods.ManuallyConvertJsonToDataTable();
            var studentRow = dataTable.Rows[0];
            var FirstName = "Conrad";
            var LastName = "Ushie";
            var BirthYear = 1995;
            var Subject = "Physics";

            Assert.IsType<DataTable?>(dataTable);
            Assert.True(dataTable.Rows.Count > 0);
            Assert.Equal(studentRow["FirstName"].ToString(), FirstName);
            Assert.Equal(studentRow["LastName"].ToString(), LastName);
            Assert.Equal(Convert.ToInt32(studentRow["BirthYear"]), BirthYear);
            Assert.Equal(studentRow["Subject"].ToString(), Subject);
        }
    }
}