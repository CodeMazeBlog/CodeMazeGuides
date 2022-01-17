using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateTimeOperators
{
    public static class Operators
    {
        public static DateTime AddOperation(DateTime dt, TimeSpan ts) 
        {
            var result = dt.Add(ts);
            return result;
        }

        public static DateTime SubtractOperation(DateTime dt, TimeSpan ts) 
        {
            var result = dt.Subtract(ts);
            return result;
        }

        public static TimeSpan SubtractOperation(DateTime dt, DateTime dt1)
        {
            var result = dt.Subtract(dt1);
            return result;
        }

        public static bool EqualityOperation(DateTime dt, DateTime dt1) 
        {
            return dt.Equals(dt1);
        }

        public static bool InequalityOperation(DateTime dt, DateTime dt1) 
        {
            return dt != dt1;
        }

        public static int CompareDates(DateTime dt, DateTime dt1) 
        {
            //return dt.CompareTo(dt1);
            return DateTime.Compare(dt, dt1);
        }

        public static bool GreaterThanOperation(DateTime dt, DateTime dt1)
        {
            return dt > dt1;
        }

        public static bool GreaterThanOrEqualOperation(DateTime dt, DateTime dt1)
        {
            return dt >= dt1;
        }

        public static bool LessThanOperation(DateTime dt, DateTime dt1)
        {
            return dt < dt1;
        }

        public static bool LessThanOrEqualOperation(DateTime dt, DateTime dt1)
        {
            return dt <= dt1;
        }
    }
}
