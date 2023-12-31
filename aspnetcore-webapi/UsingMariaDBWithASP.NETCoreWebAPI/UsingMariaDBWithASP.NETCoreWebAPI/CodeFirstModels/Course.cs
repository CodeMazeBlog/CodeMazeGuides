﻿namespace UsingMariaDBWithASP.NETCoreWebAPI.CodeFirstModels
{
    public class Course
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public int CreditUnit { get; set; }

        public virtual ICollection<Student>? Students { get; set; }
    }
}
