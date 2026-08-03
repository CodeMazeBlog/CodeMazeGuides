using System.ComponentModel.DataAnnotations;

namespace SelectWhereNotExistSqlQueryUsingLinq
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}