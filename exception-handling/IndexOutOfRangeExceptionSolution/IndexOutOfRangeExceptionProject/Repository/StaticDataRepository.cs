using System.Data;

namespace IndexOutOfRangeExceptionProject.Repository
{
    public class StaticDataRepository
    {
        public static DataTable GetGroceries()
        {
            var dataTable = new DataTable
            {
                TableName = "Groceries"
            };
            dataTable.Columns.Add("Id", typeof(int));
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Description", typeof(string));

            dataTable.Rows.Add(1, "Macaroni", "Tasty Pasta");
            dataTable.Rows.Add(2, "Ramen", "Tasty Noodles");
            dataTable.Rows.Add(3, "Figaro Oil", "Olive Oil");
            dataTable.Rows.Add(4, "XYZ Lentils", "Nutritious Pulses");

            return dataTable;
        }
    }
}