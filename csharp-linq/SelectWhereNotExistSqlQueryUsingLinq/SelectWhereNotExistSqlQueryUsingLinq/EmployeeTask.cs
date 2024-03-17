using System.ComponentModel.DataAnnotations;

namespace SelectWhereNotExistSqlQueryUsingLinq
{
    public class EmployeeTask
    {
        [Key]
        public int TaskId { get; set; }
        public int EmployeeId { get; set; }
        public string? Description { get; set; }
        public List<EmployeeTask>? Tasks { get; set; }
    }
}
