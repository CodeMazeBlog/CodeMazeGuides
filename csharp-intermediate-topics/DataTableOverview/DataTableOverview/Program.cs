using System.Data;

namespace DataTableOverview
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var dt = CreateMainDataTable();

            PopulateDataTable(dt);
            AddPrimaryKey(dt);
            PrintConstraints(dt);
            PrintData(dt);

            DataTable dtClone = dt.Clone();
            PrintColumns(dtClone);

            DataTable dtCopy = dt.Copy();
            PrintData(dtCopy);

            AddNewRow(dt);
            FilterDataTable(dt);

            PrintTable(dt);

            SalesDataProcessor.ProcessSales();
        }

        public static DataTable CreateMainDataTable()
        {
            // create initial example table
            var dt = new DataTable();

            dt.Columns.Add("Ticker", typeof(string));
            dt.Columns.Add("Date", typeof(DateTime));
            dt.Columns.Add("Price", typeof(double));

            return dt;
        }

        public static void PopulateDataTable(DataTable dt)
        {
            // 1) declare and instantiate row
            DataRow row = dt.NewRow();

            // 2) set column values
            row["Ticker"] = "MSFT";
            row["Date"] = new DateTime(2023, 3, 3);
            row["Price"] = 255.29;

            // by Ordinal/index
            row[0] = "MSFT";
            row[1] = new DateTime(2023, 3, 3);
            row[2] = 255.29;

            // 3) add populated row to table
            dt.Rows.Add(row);
        }

        public static void AddPrimaryKey(DataTable dt)
        {
            var pkCol = new DataColumn("Key", typeof(int));
            dt.Columns.Add(pkCol);

            dt.Rows[0]["Key"] = 0;

            dt.PrimaryKey = [pkCol];
        }

        public static void AddNewRow(DataTable dt)
        {
            DataRow row = dt.NewRow();

            row["Ticker"] = "AMZN";
            row["Date"] = new DateTime(2023, 3, 6);
            row["Price"] = 93.75;
            row["Key"] = 1;

            dt.Rows.Add(row);
        }

        public static void AddNewRowFromValues(DataTable dt)
        {
            dt.Rows.Add("AMZN", new DateTime(2023, 3, 6), 93.75, 1);
        }

        public static void PrintConstraints(DataTable dt)
        {
            foreach (Constraint constraint in dt.Constraints)
            {
                Console.WriteLine(constraint.ConstraintName);
                Console.WriteLine(constraint.GetType());
            }
        }

        public static void FilterDataTable(DataTable dt)
        {
            string expression = "Ticker='AMZN'";
            DataRow[] result = dt.Select(expression);

            PrintSelectedRows(result, dt);
        }

        public static void PrintSelectedRows(DataRow[] rows, DataTable dt)
        {
            foreach (DataRow dr in rows)
            {
                foreach (DataColumn col in dt.Columns)
                {
                    Console.WriteLine($"{col}: {dr[col]}");
                }
            }
        }

        public static void PrintColumns(DataTable dt)
        {
            foreach (DataColumn col in dt.Columns)
                Console.WriteLine(col.ColumnName);
        }

        public static void PrintData(DataTable dt)
        {
            foreach (DataRow row in dt.Rows)
            {
                foreach (DataColumn col in dt.Columns)
                {
                    Console.WriteLine($"{col}: {row[col]}");
                }
            }
        }

        public static void PrintTable(DataTable dt)
        {
            var header = dt.Columns.Cast<DataColumn>().Select(col => col.ColumnName);
            Console.WriteLine(string.Join(" | ", header));

            foreach (DataRow row in dt.Rows)
                Console.WriteLine(string.Join(" | ", row.ItemArray));
        }

        public static IEnumerable<string?> GetTickersBelow(DataTable dt, double price)
        {
            return dt.AsEnumerable()
                .Where(row => row.Field<double>("Price") < price)
                .Select(row => row.Field<string>("Ticker"));
        }
    }
}
