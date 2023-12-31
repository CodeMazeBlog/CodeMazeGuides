using System;
using System.Collections.Generic;

namespace UsingMariaDBWithASP.NETCoreWebAPI.DBFirstModels;

public partial class Student
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string SecondName { get; set; } = null!;

    public string? Address { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}
