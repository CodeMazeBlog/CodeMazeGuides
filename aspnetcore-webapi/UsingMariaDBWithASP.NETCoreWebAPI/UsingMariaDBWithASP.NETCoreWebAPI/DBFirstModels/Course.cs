using System;
using System.Collections.Generic;

namespace UsingMariaDBWithASP.NETCoreWebAPI.DBFirstModels;

public partial class Course
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int CreditUnit { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
