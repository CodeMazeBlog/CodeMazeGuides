using System.Data;

namespace DataTableOverview
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var dt = CreateMainDataTable();

            PopulateDataTable(dt);
            PrintData(dt);

            DataTable dtClone = dt.Clone();
            PrintColumns(dtClone);          

            DataTable dtCopy = dt.Copy();
            PrintData(dtCopy);

            AddNewRow(dt);
            FilterDataTable(dt);

            SalesDataProcessor.ProcessSales();
        }

        public static DataTable CreateMainDataTable()
        {
            // create initial example table
            var dt = new DataTable();

            dt.Columns.Add("Ticker", typeof(string));
            dt.Columns.Add("Date", typeof(DateTime));
            dt.Columns.Add("Price", typeof(double));

            // add primary key
            var pkCol = new DataColumn("Key", typeof(int));
            dt.Columns.Add(pkCol);

            var pkCols = new DataColumn[1];
            pkCols[0] = pkCol;

            dt.PrimaryKey = pkCols;

            return dt;
        }

        public static void PopulateDataTable(DataTable dt)
        {
            // add row
            // 1) declare and instantiate row
            DataRow row;
            row = dt.NewRow();

            // 2) set column values
            row["Ticker"] = "MSFT";
            row["Date"] = new DateTime(2023, 3, 3);
            row["Price"] = 255.29;  
            row["Key"] = 0;

            // by Ordinal/index
            row[0] = "MSFT";
            row[1] = new DateTime(2023, 3, 3);
            row[2] = 255.29;
            row[3] = 0;

            // 3) add populated row to table
            dt.Rows.Add(row);
        }

        public static void AddNewRow(DataTable dt)
        {
            DataRow row;
            row = dt.NewRow();

            row["Ticker"] = "AMZN";
            row["Date"] = new DateTime(2023, 3, 6);
            row["Price"] = 93.75;
            row["Key"] = 1;

            dt.Rows.Add(row);
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
    }
}